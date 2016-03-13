using FHL.Common;
using FHL.Data.Models.NHL;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHL.Data.Services.NHL
{
    public sealed class PlayerSearcher : NHLServiceBase
    {
        private const string PlayerSearchUrlFormat = "https://suggest.svc.nhl.com/svc/suggest/v1/minplayers/{0}/300";

        private static readonly Lazy<char[]> LettersLazy = new Lazy<char[]>(() => Enumerable.Range('a', 'z' - 'a').Select(x => (char)x).ToArray());

        private static readonly Lazy<IEnumerable<string>> PlayerSearchesLazy = new Lazy<IEnumerable<string>>(() => GetPlayerSearches());

        public async Task<IEnumerable<PlayerModel>> GetPlayersAsync()
        {
            using (var httpClient = HttpClientHelpers.GetHttpClientWithCaching())
            {
                var listOfBatchedTasks = PlayerSearchesLazy.Value
                    .Select(psu => HttpClientHelpers.DeserializeResponseAsync<PlayerSuggestions>(
                        httpClient,
                        string.Format(PlayerSearchUrlFormat, psu),
                        JsonSerializer))
                    .Batch(250)
                    .Select(bt => Task.WhenAll(bt));

                return (await Task.WhenAll(listOfBatchedTasks))
                        .SelectMany(ps => ps)
                        .Where(ps => ps != null && ps.Players != null && ps.Players.Count > 0)
                        .SelectMany(ps => ps.Players)
                        .DistinctBy(p => p.Id);
            }
        }

        private static IEnumerable<string> GetPlayerSearches()
        {
            for (byte a = 0; a < LettersLazy.Value.Length; a++)
                for (byte b = 0; b < LettersLazy.Value.Length; b++)
                    for (byte c = 0; c < LettersLazy.Value.Length; c++)
                        yield return string.Concat(LettersLazy.Value[a], LettersLazy.Value[b], LettersLazy.Value[c]);
        }
    }
}

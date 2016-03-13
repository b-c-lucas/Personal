using FHL.Common;
using FHL.Data.Models.NHL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FHL.Data.Services.NHL
{
    public sealed class StandingsService : NHLServiceBase
    {
        private const int NewestYear = 2015;
        private const int OldestYear = 1917;

        private const string StandingsUrl = "https://statsapi.web.nhl.com/api/v1/standings?expand=standings.team";

        public enum GetTeamsDepth : byte
        {
            CurrentYear = 0,
            AllTime = 1
        };

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            return await PerformGetTeamsAsync(httpClient =>
                HttpClientHelpers.DeserializeResponseAsync<StandingsData>(
                    httpClient,
                    StandingsUrl,
                    JsonSerializer));
        }

        public async Task<IEnumerable<Team>> GetAllTimeTeamsAsync()
        {
            var getTaskFuncs = Enumerable.Range(OldestYear, NewestYear - OldestYear)
                .Select(x =>
                {
                    Func<HttpClient, Task<StandingsData>> getTaskFunc = httpClient =>
                        HttpClientHelpers.DeserializeResponseAsync<StandingsData>(
                            httpClient,
                            StandingsUrl + "&season=" + x.ToString() + (x + 1).ToString(),
                            JsonSerializer);

                    return getTaskFunc;
                });

            return await PerformGetTeamsAsync(getTaskFuncs.ToArray());
        }

        private static async Task<IEnumerable<Team>> PerformGetTeamsAsync(params Func<HttpClient, Task<StandingsData>>[] getStandingsDataTaskFuncs)
        {
            using (var httpClient = HttpClientHelpers.GetHttpClientWithCaching())
            {
                var tasks = getStandingsDataTaskFuncs.Select(gsdtf => gsdtf.Invoke(httpClient));
                return (await Task.WhenAll(tasks))
                    .SelectMany(x => x.records)
                    .SelectMany(r => r.teamRecords)
                    .Select(tr => tr.team);
            }
        }
    }
}
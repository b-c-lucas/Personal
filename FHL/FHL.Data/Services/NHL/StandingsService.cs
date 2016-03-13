using FHL.Common;
using FHL.Data.Models.NHL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHL.Data.Services.NHL
{
    public sealed class StandingsService : NHLServiceBase
    {
        private const string StandingsUrl = "https://statsapi.web.nhl.com/api/v1/standings?expand=standings.team";

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            StandingsData standings;

            using (var httpClient = HttpClientHelpers.GetHttpClientWithCaching())
            {
                standings = await HttpClientHelpers.DeserializeResponseAsync<StandingsData>(
                    httpClient,
                    StandingsUrl,
                    JsonSerializer);
            }

            return standings.records.SelectMany(r => r.teamRecords).Select(tr => tr.team);
        }
    }
}
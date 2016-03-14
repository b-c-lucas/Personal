using FHL.Common;
using FHL.Data.Models.NHL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHL.Data.Services.NHL
{
    public sealed class ScheduleService : NHLServiceBase
    {
        private const string ScheduleUrlFormat = "https://statsapi.web.nhl.com/api/v1/schedule?startDate={0}&endDate={1}";

        public async Task<IEnumerable<Game>> GetGamesAsync(DateTime? datetime = null)
        {
            ScheduleData scheduleData;

            using (var httpClient = HttpClientHelpers.GetHttpClientWithCaching())
            {
                scheduleData = await HttpClientHelpers.DeserializeResponseAsync<ScheduleData>(
                    httpClient,
                    GetScheduleUrl(additionalUrl: "&expand=schedule.scoringplays&site=en_nhl"),
                    JsonSerializer);
            }

            return scheduleData.Games.Where(g => g != null);
        }

        public async Task<IDictionary<string, Game[]>> GetAllGamesAsync()
        {
            ScheduleData scheduleData;

            using (var httpClient = HttpClientHelpers.GetHttpClientWithCaching())
            {
                scheduleData = await HttpClientHelpers.DeserializeResponseAsync<ScheduleData>(
                    httpClient,
                    GetScheduleUrl(new DateTime(2015, 10, 1), new DateTime(2016, 5, 1)),
                    JsonSerializer);
            }

            return scheduleData.dates
                .Where(d => d != null)
                .ToDictionary(
                    d => d.date, 
                    d => d.games.Where(g => g != null).ToArray());
        }

        private static Uri GetScheduleUrl(
            DateTime? start = null,
            DateTime? end = null,
            string additionalUrl = null)
        {
            Uri uri;
            return Uri.TryCreate(
                string.Format(
                    ScheduleUrlFormat + (string.IsNullOrEmpty(additionalUrl) ? string.Empty : additionalUrl),
                    (start ?? DateTime.Now).Date.ToShortDateString(),
                    (end ?? DateTime.Now).Date.ToShortDateString()),
                UriKind.Absolute,
                out uri)
                ? uri
                : null;
        }
    }
}
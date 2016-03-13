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
        private const string ScheduleUrlFormat = "https://statsapi.web.nhl.com/api/v1/schedule?startDate={0}&endDate={0}";

        public async Task<IEnumerable<Game>> GetGamesAsync(DateTime? datetime = null)
        {
            ScheduleData scheduleData;

            using (var httpClient = HttpClientHelpers.GetHttpClientWithCaching())
            {
                scheduleData = await HttpClientHelpers.DeserializeResponseAsync<ScheduleData>(
                    httpClient,
                    GetScheduleUrl(datetime, "&expand=schedule.scoringplays&site=en_nhl"),
                    JsonSerializer);
            }

            return scheduleData.Games.Where(g => g != null);
        }

        private static Uri GetScheduleUrl(DateTime? datetime = null, string additionalUrl = null)
        {
            Uri uri;
            return Uri.TryCreate(
                string.Format(
                    ScheduleUrlFormat + (string.IsNullOrEmpty(additionalUrl) ? string.Empty : additionalUrl),
                    (datetime ?? DateTime.Now).Date.ToShortDateString()),
                UriKind.Absolute,
                out uri)
                ? uri
                : null;
        }
    }
}
using FHL.Data.DB.NHL;
using FHL.Data.DB.NHL.Repositories;
using FHL.Data.Models.NHL;
using FHL.Data.Services.NHL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

using PlayerEntity = FHL.Data.DB.NHL.Entities.Player;
using TeamEntity = FHL.Data.DB.NHL.Entities.Team;

namespace FHL.API.Data.Controllers
{
    [RoutePrefix("nhl")]
    public sealed class NhlDataController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<Game>> Index()
        {
            var scheduleService = new ScheduleService();

            var games = await scheduleService.GetGamesAsync();

            return games;
        }

        [HttpGet]
        [Route("Players")]
        public async Task<IEnumerable<PlayerEntity>> Players()
        {
            using (var context = new NHLContext())
            {
                var x = new PlayerRepository(context);

                return (await x.GetPlayersAsync()).Where(p => p.IsActive && p.Position == "G").OrderBy(p => p.LastName);
            }
        }

        [HttpGet]
        [Route("PointGetters")]
        public async Task<IEnumerable<Player>> PointGetters(DateTime? datetime = null)
        {
            var scheduleService = new ScheduleService();

            var games = await scheduleService.GetGamesAsync(datetime);

            return games
                .Where(g => g.scoringPlays != null && g.scoringPlays.Any())
                .SelectMany(g => g.scoringPlays)
                .Where(sp => sp != null && sp.players != null && sp.players.Any())
                .SelectMany(sp => sp.players);
        }
        
        [HttpGet]
        [Route("Teams")]
        public async Task<IEnumerable<TeamEntity>> Teams()
        {
            using (var context = new NHLContext())
            {
                var x = new TeamRepository(context);

                return (await x.GetTeamsAsync()).OrderBy(t => t.Abbreviation);
            }
        }
    }
}
using FHL.Data.DB.NHL;
using FHL.Data.DB.NHL.Repositories;
using FHL.Data.Models.NHL;
using FHL.Data.Services.NHL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

using PlayerEntity = FHL.Data.DB.NHL.Entities.Player;
using TeamEntity = FHL.Data.DB.NHL.Entities.Team;

namespace FHL.API.Data.Controllers
{
    [RoutePrefix("api/nhl")]
    [CacheOutput(ClientTimeSpan = 600, ServerTimeSpan = 600)]
    public sealed class NhlDataController : ApiController
    {
        [HttpGet]
        [Route("Forwards")]
        public async Task<IEnumerable<PlayerModel>> Forwards()
        {
            return await GetPlayersOfTypeAsync('L', 'C', 'R');
        }

        [HttpGet]
        [Route("Defencemen")]
        public async Task<IEnumerable<PlayerModel>> Defencemen()
        {
            return await GetPlayersOfTypeAsync('D');
        }

        [HttpGet]
        [Route("Goalies")]
        public async Task<IEnumerable<PlayerModel>> Goalies()
        {
            return await GetPlayersOfTypeAsync('G');
        }

        [HttpGet]
        [Route("PointGetters")]
        public async Task<IEnumerable<PointGetter>> PointGetters(DateTime? datetime = null)
        {
            var scheduleService = new ScheduleService();

            var games = await scheduleService.GetGamesAsync(datetime);

            return games
                .Where(g => g.scoringPlays != null && g.scoringPlays.Any())
                .SelectMany(g => g.scoringPlays)
                .Where(sp => sp != null && sp.players != null && sp.players.Any())
                .SelectMany(sp => sp.players)
                .Select(p => new PointGetter
                {
                    Name = p.player.fullName,
                    Points = p.playerType == "Scorer"
                        ? 1
                        : (p.playerType == "Assist" ? 0.5 : (double?)null)
                });
        }

        [HttpGet]
        [Route("Teams")]
        public async Task<IEnumerable<TeamEntity>> Teams()
        {
            IList<TeamEntity> teams;

            using (var context = new NHLContext())
            {
                teams = await new TeamRepository(context).ToListAsync();
            }

            return teams.OrderBy(t => t.Abbreviation);
        }

        private static async Task<IEnumerable<PlayerModel>> GetPlayersOfTypeAsync(params char[] positions)
        {
            IList<PlayerEntity> players;

            using (var context = new NHLContext())
            {
                players = await new PlayerRepository(context).ToListAsync();
            }

            return players
                .Where(p => p.IsActive && positions.Contains(p.GetPositionAsChar()))
                .OrderBy(p => p.LastName)
                .Select(p => new PlayerModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    IsActive = p.IsActive,
                    PlayerLink = p.PlayerLink,
                    Position = p.GetPositionAsChar(),
                    TeamAbbreviation = p.Team.Abbreviation
                });
        }
        
        public struct PointGetter
        {
            public string Name;
            public double? Points;
        }
    }
}
using FHL.Common;
using FHL.Data.DB.FHL;
using FHL.Data.Models.NHL;
using FHL.Data.Services.NHL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FHL.Updater.FHL
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer<FHLContext>(null);

            //using (var context = new FHLContext())
            //{
            //    var teamRepository = new TeamRepository(context);
            //    var playerRepository = new PlayerRepository(context);
            //}

            AsyncHelpers.RunSync(() => UpdateGames());
        }

        private static async Task UpdateGames()
        {
            var regularSeasonGames = new List<KeyValuePair<string, Game[]>>(82);
            var firstRoundGames = new List<KeyValuePair<string, Game[]>>(7);
            var secondRoundGames = new List<KeyValuePair<string, Game[]>>(7);
            var thirdRoundGames = new List<KeyValuePair<string, Game[]>>(7);
            var fourthRoundGames = new List<KeyValuePair<string, Game[]>>(7);

            var games = await new ScheduleService().GetAllGamesAsync();

            foreach (var game in games.Where(g => g.Value.Length >= 6))
            {
                if (regularSeasonGames.Count < 82)
                {
                    regularSeasonGames.Add(game);
                }
                else if (firstRoundGames.Count < 7)
                {
                    firstRoundGames.Add(game);
                }
                else if (secondRoundGames.Count < 7)
                {
                    secondRoundGames.Add(game);
                }
                else if (thirdRoundGames.Count < 7)
                {
                    thirdRoundGames.Add(game);
                }
                else if (fourthRoundGames.Count < 7)
                {
                    fourthRoundGames.Add(game);
                }
            }

            var brad = games.ToString();
        }
    }
}
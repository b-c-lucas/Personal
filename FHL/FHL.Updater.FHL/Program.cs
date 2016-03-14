using FHL.Data.DB.FHL;
using FHL.Data.DB.FHL.Repositories;
using System.Data.Entity;

namespace FHL.Updater.FHL
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer<FHLContext>(null);

            using (var context = new FHLContext())
            {
                var teamRepository = new TeamRepository(context);
                var playerRepository = new PlayerRepository(context);
            }
        }
    }
}
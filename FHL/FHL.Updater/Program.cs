using FHL.Common;
using FHL.Data.Services.NHL;
using System.Threading.Tasks;

namespace FHL.Updater
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            AsyncHelpers.RunSync(() => DoWork());
        }

        private static async Task DoWork()
        {
            var playerSearcher = new PlayerSearcher();

            var players = await playerSearcher.GetPlayersAsync();
        }
    }
}
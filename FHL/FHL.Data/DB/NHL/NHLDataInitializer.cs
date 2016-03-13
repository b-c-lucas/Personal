using FHL.Common;
using FHL.Data.DB.NHL.Entities;
using FHL.Data.Services.NHL;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace FHL.Data.DB.NHL
{
    public sealed class NHLDataInitializer : CreateDatabaseIfNotExists<NHLContext>
    {
        private readonly PlayerSearcher playerSearcher;

        private readonly StandingsService standingsService;

        public NHLDataInitializer()
            : this(new PlayerSearcher(), new StandingsService())
        {
        }

        public NHLDataInitializer(PlayerSearcher playerSearcher, StandingsService standingsService)
        {
            this.playerSearcher = playerSearcher;
            this.standingsService = standingsService;
        }

        protected override void Seed(NHLContext context)
        {
            base.Seed(context);

            AsyncHelpers.RunSync(() => this.Update(context));
        }

        private async Task Update(NHLContext context)
        {
            await Task.WhenAll(this.UpdatePlayers(context), this.UpdateTeams(context));

            await context.SaveChangesAsync();
        }

        private async Task UpdatePlayers(NHLContext context)
        {
            var players = await this.playerSearcher.GetPlayersAsync();

            foreach (var player in players.AsParallel())
            {
                context.Players.AddOrUpdate(
                    new Player
                    {
                        Id = player.Id,
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        IsActive = player.IsActive,
                        Position = player.Position,
                        TeamAbbreviation = player.TeamAbbreviation,
                        PlayerLink = player.PlayerLink
                    });
            }
        }

        private async Task UpdateTeams(NHLContext context)
        {
            var teams = await this.standingsService.GetTeamsAsync();

            foreach (var team in teams.AsParallel())
            {
                context.Teams.AddOrUpdate(
                    new Team
                    {
                        Id = team.id,
                        Name = team.name,
                        Abbreviation = team.abbreviation
                    });
            }
        }
    }
}

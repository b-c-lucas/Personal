using FHL.Data.DB.FHL.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq.Expressions;

namespace FHL.Data.DB.FHL
{
    public sealed class FHLContext : ContextBase
    {
        public FHLContext()
            : base(nameof(FHLContext))
        {
        }

        public DbSet<Conference> Conferences { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<GamePlayed> GamesPlayed { get; set; }

        public DbSet<League> Leagues { get; set; }
        
        public DbSet<Lineup> Lineups { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override string Schema => "FHL";

        protected override void BuildModels(DbModelBuilder modelBuilder)
        {
            var season = modelBuilder.Entity<Season>();
            SetUpForeignKey(season, s => s.League, s => s.LeagueId);

            var conference = modelBuilder.Entity<Conference>();
            SetUpForeignKey(conference, c => c.League, c => c.LeagueId);

            var team = modelBuilder.Entity<Team>();
            SetUpForeignKey(team, t => t.Conference, t => t.ConferenceId);

            var game = modelBuilder.Entity<Game>();
            SetUpForeignKey(game, g => g.Season, g => g.SeasonId);
            SetUpForeignKey(game, g => g.HomeLineup, g => g.HomeLineupId);
            SetUpForeignKey(game, g => g.AwayLineup, g => g.AwayLineupId);

            var lineup = modelBuilder.Entity<Lineup>();
            SetUpForeignKey(lineup, l => l.Team, l => l.TeamId);
            SetUpForeignKey(lineup, l => l.Forward1GamePlayed, l => l.Forward1GamePlayedId);
            SetUpForeignKey(lineup, l => l.Forward2GamePlayed, l => l.Forward2GamePlayedId);
            SetUpForeignKey(lineup, l => l.Forward3GamePlayed, l => l.Forward3GamePlayedId);
            SetUpForeignKey(lineup, l => l.Forward4GamePlayed, l => l.Forward4GamePlayedId);
            SetUpForeignKey(lineup, l => l.Forward5GamePlayed, l => l.Forward5GamePlayedId);
            SetUpForeignKey(lineup, l => l.Forward6GamePlayed, l => l.Forward6GamePlayedId);
            SetUpForeignKey(lineup, l => l.Defenceman1GamePlayed, l => l.Defenceman1GamePlayedId);
            SetUpForeignKey(lineup, l => l.Defenceman2GamePlayed, l => l.Defenceman2GamePlayedId);
            SetUpForeignKey(lineup, l => l.Defenceman3GamePlayed, l => l.Defenceman3GamePlayedId);
            SetUpForeignKey(lineup, l => l.Defenceman4GamePlayed, l => l.Defenceman4GamePlayedId);

            var gamePlayed = modelBuilder.Entity<GamePlayed>();
            SetUpForeignKey(gamePlayed, gp => gp.Lineup, gp => gp.LineupId);
            SetUpForeignKey(gamePlayed, gp => gp.Player, gp => gp.PlayerId);
        }

        private static void SetUpForeignKey<TEntity, TForeignKey, TForeignEntity>(
            EntityTypeConfiguration<TEntity> entityTypeConfiguration,
            Expression<Func<TEntity, TForeignEntity>> hasRequiredFuncExpression,
            Expression<Func<TEntity, TForeignKey>> hasForeignKeyFuncExpression)
            where TEntity : EntityBase
            where TForeignEntity : EntityBase
        {
            entityTypeConfiguration
                .HasRequired(hasRequiredFuncExpression)
                .WithMany()
                .HasForeignKey(hasForeignKeyFuncExpression)
                .WillCascadeOnDelete(false);
        }
    }
}
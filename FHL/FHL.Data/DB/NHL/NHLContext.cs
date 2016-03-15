using FHL.Data.DB.NHL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace FHL.Data.DB.NHL
{
    public sealed class NHLContext : ContextBase
    {
        public NHLContext()
            : base(nameof(NHLContext))
        {
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override string Schema => "NHL";

        protected override void BuildModels(DbModelBuilder modelBuilder)
        {
            var team = modelBuilder.Entity<Team>();
            team.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            var player = modelBuilder.Entity<Player>();
            player.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            player.HasRequired(p => p.Team).WithMany().HasForeignKey(p => p.TeamId);
        }
    }
}
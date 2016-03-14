using FHL.Data.DB.FHL.Entities;
using System.Data.Entity;

namespace FHL.Data.DB.FHL
{
    public sealed class FHLContext : ContextBase
    {
        public FHLContext()
            : base(nameof(FHLContext))
        {
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override string Schema => "FHL";

        protected override void BuildModels(DbModelBuilder modelBuilder)
        {
            var team = modelBuilder.Entity<Team>();
            team.HasKey(t => t.Id);

            var player = modelBuilder.Entity<Player>();
            player.HasKey(p => p.Id);
            player.Property(p => p.NHLId).IsRequired();
        }
    }
}
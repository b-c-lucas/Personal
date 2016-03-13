using FHL.Data.DB.NHL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;

namespace FHL.Data.DB.NHL
{
    public sealed class NHLContext : ContextBase
    {
        public NHLContext()
            : base(ConfigurationManager.ConnectionStrings["NHLContextConnection"].ConnectionString)
        {
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override string Schema => "NHL";

        protected override void BuildModels(DbModelBuilder modelBuilder)
        {
            var team = modelBuilder.Entity<Team>();
            team.HasKey(t => t.Id);
            team.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            team.Property(t => t.Name).IsRequired().HasMaxLength(100);
            team.Property(t => t.Abbreviation).IsRequired().HasMaxLength(3);

            var player = modelBuilder.Entity<Player>();
            player.HasKey(p => p.Id);
            player.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            player.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            player.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            player.Property(p => p.Position).IsRequired();
            player.Property(p => p.IsActive).IsRequired();
            player.Property(p => p.PlayerLink).IsOptional();

            player.Property(p => p.TeamId).IsRequired();
            player.HasRequired(p => p.Team).WithMany().HasForeignKey(p => p.TeamId);
        }
    }
}
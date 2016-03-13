using FHL.Data.DB.NHL.Entities;
using System.Data.Entity;

namespace FHL.Data.DB.NHL
{
    public sealed class NHLContext : ContextBase
    {
        public NHLContext()
            : base("NHLContext")
        {
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}

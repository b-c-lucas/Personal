using FHL.Data.DB.FHL.Entities;
using System.Data.Entity;

namespace FHL.Data.DB.FHL.Repositories
{
    public sealed class PlayerRepository : FHLRepositoryBase<Player>
    {
        public PlayerRepository(FHLContext context)
            : base(context)
        {
        }

        protected override DbSet<Player> Set => this.Context.Players;
    }
}
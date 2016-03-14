using FHL.Data.DB.NHL.Entities;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FHL.Data.DB.NHL.Repositories
{
    public sealed class PlayerRepository : NHLRepositoryBase<Player>
    {
        public PlayerRepository(NHLContext context)
            : base(context)
        {
        }

        protected override DbSet<Player> Set => this.Context.Players;

        public override async Task<IList<Player>> ToListAsync()
        {
            return await this.Set.Include(p => p.Team).ToListAsync();
        }
    }
}
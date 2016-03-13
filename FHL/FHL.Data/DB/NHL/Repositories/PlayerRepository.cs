using FHL.Data.DB.NHL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FHL.Data.DB.NHL.Repositories
{
    public sealed class PlayerRepository : RepositoryBase
    {
        public PlayerRepository(NHLContext context)
            : base(context)
        {
        }

        public async Task<IList<Player>> GetPlayersAsync()
        {
            return await this.Context.Players.ToListAsync();
        }
    }
}
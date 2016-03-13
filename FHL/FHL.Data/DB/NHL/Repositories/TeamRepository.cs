using FHL.Data.DB.NHL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FHL.Data.DB.NHL.Repositories
{
    public sealed class TeamRepository : RepositoryBase
    {
        public TeamRepository(NHLContext context)
            : base(context)
        {
        }

        public async Task<IList<Team>> GetTeamsAsync()
        {
            return await this.Context.Teams.ToListAsync();
        }
    }
}
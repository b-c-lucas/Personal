using FHL.Data.DB.FHL.Entities;
using System.Data.Entity;

namespace FHL.Data.DB.FHL.Repositories
{
    public sealed class TeamRepository : FHLRepositoryBase<Team>
    {
        public TeamRepository(FHLContext context)
            : base(context)
        {
        }

        protected override DbSet<Team> Set => this.Context.Teams;
    }
}
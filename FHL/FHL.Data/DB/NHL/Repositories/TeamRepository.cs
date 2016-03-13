using FHL.Data.DB.NHL.Entities;
using System.Data.Entity;

namespace FHL.Data.DB.NHL.Repositories
{
    public sealed class TeamRepository : RepositoryBase<Team>
    {
        public TeamRepository(NHLContext context)
            : base(context)
        {
        }

        protected override DbSet<Team> Set => this.Context.Teams;
    }
}
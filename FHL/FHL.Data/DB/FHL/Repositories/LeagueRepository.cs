using FHL.Data.DB.FHL.Entities;
using System.Data.Entity;

namespace FHL.Data.DB.FHL.Repositories
{
    public sealed class LeagueRepository : FHLRepositoryBase<League>
    {
        public LeagueRepository(FHLContext context)
            : base(context)
        {
        }

        protected override DbSet<League> Set => this.Context.Leagues;
    }
}
using FHL.Data.DB.FHL.Entities;
using System.Data.Entity;

namespace FHL.Data.DB.FHL.Repositories
{
    public sealed class LineupRepository : FHLRepositoryBase<Lineup>
    {
        public LineupRepository(FHLContext context)
            : base(context)
        {
        }

        protected override DbSet<Lineup> Set => this.Context.Lineups;
    }
}
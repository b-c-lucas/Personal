using FHL.Data.DB.FHL.Entities;
using System.Data.Entity;

namespace FHL.Data.DB.FHL.Repositories
{
    public sealed class SeasonRepository : FHLRepositoryBase<Season>
    {
        public SeasonRepository(FHLContext context)
            : base(context)
        {
        }

        protected override DbSet<Season> Set => this.Context.Seasons;
    }
}
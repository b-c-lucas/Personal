using FHL.Data.DB.FHL.Entities;
using System.Data.Entity;

namespace FHL.Data.DB.FHL.Repositories
{
    public sealed class ConferenceRepository : FHLRepositoryBase<Conference>
    {
        public ConferenceRepository(FHLContext context)
            : base(context)
        {
        }

        protected override DbSet<Conference> Set => this.Context.Conferences;
    }
}
using FHL.Data.DB.FHL.Entities;
using System.Data.Entity;

namespace FHL.Data.DB.FHL.Repositories
{
    public sealed class GamesPlayedRepository : FHLRepositoryBase<GamePlayed>
    {
        public GamesPlayedRepository(FHLContext context)
            : base(context)
        {
        }

        protected override DbSet<GamePlayed> Set => this.Context.GamesPlayed;
    }
}
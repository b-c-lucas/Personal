using FHL.Data.DB.FHL.Entities;
using System.Data.Entity;

namespace FHL.Data.DB.FHL.Repositories
{
    public sealed class GameRepository : FHLRepositoryBase<Game>
    {
        public GameRepository(FHLContext context)
            : base(context)
        {
        }

        protected override DbSet<Game> Set => this.Context.Games;
    }
}
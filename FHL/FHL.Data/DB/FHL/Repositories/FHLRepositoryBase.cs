using FHL.Data.DB.Repositories;

namespace FHL.Data.DB.FHL.Repositories
{
    public abstract class FHLRepositoryBase<TEntity> : RepositoryBase<FHLContext, TEntity>
        where TEntity : FHLEntityBase
    {
        public FHLRepositoryBase(FHLContext context)
            : base(context)
        {
        }
    }
}
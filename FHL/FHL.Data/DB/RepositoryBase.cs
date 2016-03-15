using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FHL.Data.DB.Repositories
{
    public abstract class RepositoryBase<TContext, TEntity>
        where TContext : DbContext
        where TEntity : EntityBase
    {
        public RepositoryBase(TContext context)
        {
            this.Context = context;
        }

        protected TContext Context { get; private set; }

        protected abstract DbSet<TEntity> Set { get; }

        public TEntity Add(TEntity entity)
        {
            return this.Set.Add(entity);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await (predicate == null ? this.Set.FirstOrDefaultAsync() : this.Set.FirstOrDefaultAsync(predicate));
        }

        public async Task SaveChangesAsync()
        {
            await this.Context.SaveChangesAsync();
        }
        
        public virtual async Task<IList<TEntity>> ToListAsync()
        {
            return await this.Set.ToListAsync();
        }
    }
}
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FHL.Data.DB
{
    public abstract class ContextBase : DbContext
    {
        protected abstract string Schema { get; }

        public ContextBase(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        {
        }

        protected abstract void BuildModels(DbModelBuilder modelBuilder);

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(this.Schema);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            this.BuildModels(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }        
    }
}
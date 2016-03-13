using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FHL.Data.DB
{
    public abstract class ContextBase : DbContext
    {
        public ContextBase(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
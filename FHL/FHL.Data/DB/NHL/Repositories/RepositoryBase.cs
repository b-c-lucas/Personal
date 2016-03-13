namespace FHL.Data.DB.NHL.Repositories
{
    public abstract class RepositoryBase
    {
        public RepositoryBase(NHLContext context)
        {
            this.Context = context;
        }

        protected NHLContext Context { get; private set; }
    }
}

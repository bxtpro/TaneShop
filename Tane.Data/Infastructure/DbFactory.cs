namespace Tane.Data.Infastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private TaneDbContext dbContext;

        public TaneDbContext Init()
        {
            return dbContext ?? (dbContext = new TaneDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
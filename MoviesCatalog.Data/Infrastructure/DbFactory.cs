
using MoviesCatalog.Model;

namespace MoviesCatalog.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        CatalogEntities dbContext;

        public CatalogEntities Init()
        {
            return dbContext ?? (dbContext = new CatalogEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}

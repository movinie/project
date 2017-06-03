using System;
using MoviesCatalog.Model;

namespace MoviesCatalog.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        CatalogEntities Init();
    }
}

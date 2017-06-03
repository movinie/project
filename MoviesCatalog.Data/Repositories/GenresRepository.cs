using System.Collections.Generic;
using MoviesCatalog.Data.Infrastructure;
using MoviesCatalog.Model;

namespace MoviesCatalog.Data.Repositories
{
    public class GenresRepository : RepositoryBase<Genres>, IGenresRepository
    {
        public GenresRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<Genres> GetAll()
        {
            return base.GetAll();
        }
    }

    public interface IGenresRepository : IRepository<Genres>
    {
        IEnumerable<Genres> GetAll();
    }
}

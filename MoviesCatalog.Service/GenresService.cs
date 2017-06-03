using System.Collections.Generic;
using MoviesCatalog.Data.Repositories;
using MoviesCatalog.Model;

namespace MoviesCatalog.Service
{
    public interface IGenresService
    {
        IEnumerable<Genres> GetAll();
    }

    public class GenresService : IGenresService
    {
        private readonly IGenresRepository _genresRepository;

        public GenresService(IGenresRepository genresRepository)
        {
            _genresRepository = genresRepository;
        }

        public IEnumerable<Genres> GetAll()
        {
            return _genresRepository.GetAll();
        }
    }
}

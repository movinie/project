using System.Collections.Generic;
using MoviesCatalog.Data.Repositories;
using MoviesCatalog.Model;

namespace MoviesCatalog.Service
{
    public interface IMoviesService
    {
        Movies Get(int id);
        IEnumerable<Movies> Get(int page, int pageSize);
        void Save(Movies movie);
        void Update(Movies movie);
        int Count();
    }

    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        
        public Movies Get(int id)
        {
            return _moviesRepository.Get(id);
        }

        public IEnumerable<Movies> Get(int page, int pageSize)
        {
            return _moviesRepository.Get(page, pageSize);
        }

        public void Save(Movies movie)
        {
            _moviesRepository.Save(movie);
        }

        public void Update(Movies movie)
        {
            _moviesRepository.Update(movie);
        }

        public int Count()
        {
            return _moviesRepository.Count();
        }
    }
}

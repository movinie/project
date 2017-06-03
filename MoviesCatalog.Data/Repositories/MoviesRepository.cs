using System.Collections.Generic;
using System.Linq;
using MoviesCatalog.Data.Infrastructure;
using MoviesCatalog.Model;

namespace MoviesCatalog.Data.Repositories
{
    public class MoviesRepository : RepositoryBase<Movies>, IMoviesRepository
    {
        public MoviesRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Movies Get(string movieName)
        {
            return DbContext.Movies.FirstOrDefault(c => c.Name == movieName);
        }

        public IEnumerable<Movies> Get(int page, int pageSize)
        {
            return DbContext
                .Movies
                .Include("MovieGenres.Genres")
                .OrderBy(m => m.Id)
                .Skip(page*pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Movies Get(int id)
        {
            return DbContext
                .Movies
                .Include("MovieGenres.Genres")
                .FirstOrDefault(m=>m.Id==id);
        }

        public void Save(Movies movie)
        {
            if (movie.Id == 0)
                Add(movie);
            else
            {
                var item = DbContext
                    .Movies
                    .Include("MovieGenres")
                    .FirstOrDefault(m => m.Id == movie.Id);
                if (item != null)
                {
                    DbContext.Entry(item).CurrentValues.SetValues(movie);
                    if (item.MovieGenres != null && item.MovieGenres.Any())
                    {
                        foreach (var movieGenre in item.MovieGenres.ToList())
                        {
                            if (movie.MovieGenres.FirstOrDefault(m => m.GenreId == movieGenre.GenreId) == null)
                                DbContext.MovieGenres.Remove(movieGenre);
                        }
                    }
                    foreach (var genre in movie.MovieGenres)
                    {
                        if (item.MovieGenres != null && (!item.MovieGenres.Any() ||
                                                         item.MovieGenres.FirstOrDefault(m => m.GenreId == genre.GenreId) ==
                                                         null))
                        {
                            var movieGenre = new MovieGenres {GenreId = genre.GenreId, MovieId = item.Id};
                            DbContext.MovieGenres.Attach(movieGenre);
                            DbContext.MovieGenres.Add(movieGenre);
                        }
                    }
                    DbContext.SaveChanges();
                }
            }
        }

        public override void Update(Movies entity)
        {
            entity.Name = entity.Name;
            base.Update(entity);
        }
    }

    public interface IMoviesRepository : IRepository<Movies>
    {
        Movies Get(string movieName);
        IEnumerable<Movies> Get(int page, int pageSize);
        Movies Get(int id);
        void Save(Movies movie);
    }
}

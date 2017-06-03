using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using MoviesCatalog.Model;
using MoviesCatalog.Service;
using MoviesCatalog.Web.ViewModels;

namespace MoviesCatalog.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly IGenresService _genresService;
        private const int DefaultPageSize = 10;

        public MoviesController(IMoviesService moviesService,IGenresService genresService)
        {
            _moviesService = moviesService;
            _genresService = genresService;
        }

        public ActionResult Index(int page = 1)
        {
            var movies = _moviesService.Get(page - 1, DefaultPageSize);
            var viewModelMovies = Mapper.Map<IEnumerable<Movies>, IEnumerable<MovieViewModel>>(movies);
            var model = new MoviesViewModel(viewModelMovies,
                new PageInfo(page, DefaultPageSize, _moviesService.Count()));


            if (Request.IsAjaxRequest())
                return PartialView("Partials/_MoviesContent", model);
            return View(model);
        }

        public ActionResult Movie(int id = 0)
        {
            MovieViewModel model = null;
            if (id > 0)
            {
                model = Mapper.Map<Movies, MovieViewModel>(_moviesService.Get(id));
            }
            else
            {
                model = new MovieViewModel();
            }
            return View(model);
        }

        public ActionResult Edit(int id = 0)
        {
            EditMovieViewModel model = null;
            var genres = Mapper.Map<IEnumerable<Genres>, IEnumerable<GenreViewModel>>(_genresService.GetAll());
            if (id > 0)
            {
                var movie = _moviesService.Get(id);
                if (movie != null)
                {
                    model = Mapper.Map<Movies, EditMovieViewModel>(movie);
                    model.AllGenres = genres;
                }
            }
            else
            {
                model = new EditMovieViewModel(genres);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMovie(EditMovieViewModel form)
        {
            _moviesService.Save(Mapper.Map<EditMovieViewModel, Movies>(form));
            return RedirectToAction("Index");
        }
    }
}
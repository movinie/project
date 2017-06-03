using System;
using System.Collections.Generic;

namespace MoviesCatalog.Web.ViewModels
{
    public class MoviesViewModel
    {
        public MoviesViewModel(IEnumerable<MovieViewModel> movies, PageInfo pageInfo)
        {
            Movies = movies;
            PageInfo = pageInfo;
        }
        public PageInfo PageInfo { get; set; }
        public IEnumerable<MovieViewModel> Movies { get; set; }
    }

    public class PageInfo
    {
        public PageInfo(int page, int pageSize, int totalItems)
        {
            CurrentPage = page;
            NextPage = page + 1;
            PageSize = pageSize;
            TotalItems = totalItems;
        }
        public int CurrentPage { get; set; }
        public int NextPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }

    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short? Year { get; set; }
        public string Director { get; set; }
        public string Link { get; set; }
        public List<string> Genres { get; set; }
    }

    public class EditMovieViewModel
    {
        public EditMovieViewModel(){}
        public EditMovieViewModel(IEnumerable<GenreViewModel> genres)
        {
            AllGenres = genres;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short? Year { get; set; }
        public string Director { get; set; }
        public string Link { get; set; }
        public IEnumerable<GenreViewModel> AllGenres { get; set; }
        public IEnumerable<int> MovieGenres { get; set; }
    }
}
using System.Linq;
using AutoMapper;
using MoviesCatalog.Model;
using MoviesCatalog.Web.ViewModels;

namespace MoviesCatalog.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Genres, GenreViewModel>()
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name));

            Mapper.CreateMap<int, MovieGenres>()
                .ForMember(g => g.GenreId, map => map.MapFrom(vm => vm));

            Mapper.CreateMap<Movies, EditMovieViewModel>()
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Year, map => map.MapFrom(vm => vm.Year))
                .ForMember(g => g.Director, map => map.MapFrom(vm => vm.Director))
                .ForMember(g => g.Link, map => map.MapFrom(vm => vm.Link))
                .ForMember(g => g.MovieGenres,
                    map => map.MapFrom(vm => vm.MovieGenres != null && vm.MovieGenres.Any()
                        ? vm.MovieGenres.Select(m => m.Genres.Id)
                        : null));

            Mapper.CreateMap<Movies, MovieViewModel>()
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Year, map => map.MapFrom(vm => vm.Year))
                .ForMember(g => g.Director, map => map.MapFrom(vm => vm.Director))
                .ForMember(g => g.Link, map => map.MapFrom(vm => vm.Link))
                .ForMember(g => g.Genres,
                    map => map.MapFrom(vm => vm.MovieGenres != null && vm.MovieGenres.Any()
                        ? vm.MovieGenres.Select(m => m.Genres.Name)
                        : null));

            Mapper.CreateMap<EditMovieViewModel, Movies>()
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Year, map => map.MapFrom(vm => vm.Year))
                .ForMember(g => g.Director, map => map.MapFrom(vm => vm.Director))
                .ForMember(g => g.Link, map => map.MapFrom(vm => vm.Link));
        }
    }
}
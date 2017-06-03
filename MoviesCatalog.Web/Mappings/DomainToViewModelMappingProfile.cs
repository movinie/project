using AutoMapper;
using MoviesCatalog.Model;
using MoviesCatalog.Web.ViewModels;

namespace MoviesCatalog.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Movies, MovieViewModel>();
        }
    }
}
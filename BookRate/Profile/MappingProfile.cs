namespace BookRate.Profile
{
    using AutoMapper;
    using BookRate.BLL.ViewModels;
    using BookRate.DAL.DTO;
    using BookRate.DAL.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contributor, ContributorViewModel>();
            CreateMap<CreateContributorDTO, Contributor>();
            CreateMap<UpdateContributorDTO, Contributor>();

            CreateMap<Role, RoleViewModel>();

            CreateMap<Edition, EditionViewModel>();
            CreateMap<CreateEditionDTO, Edition>();
            CreateMap<UpdateEditionDTO, Edition>();

        }
    }
}

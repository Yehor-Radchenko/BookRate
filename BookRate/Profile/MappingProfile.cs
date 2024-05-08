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

            CreateMap<Setting, SettingViewModel>();
            CreateMap<CreateSettingDTO, Setting>();
            CreateMap<UpdateSettingDTO, Setting>();

            CreateMap<Serie, SerieViewModel>();
            CreateMap<CreateSerieDTO, Serie>();
            CreateMap<UpdateSerieDTO, Serie>();

            CreateMap<Narrative, NarrativeViewModel>();
            CreateMap<CreateNarrativeDTO, Narrative>();
            CreateMap<UpdateNarrativeDTO, Narrative>();

            CreateMap<Book, BookViewModel>();
            CreateMap<CreateBookDTO, Book>();
            CreateMap<UpdateBookDTO, Book>();

            CreateMap<CreateBookEditionDTO, BookEdition>()
            .ForMember(dest => dest.BookId, opt => opt.Ignore());
        }
    }
}

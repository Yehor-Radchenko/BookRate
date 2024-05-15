namespace BookRate.Profile
{
    using AutoMapper;
    using BookRate.BLL.ViewModels.Book;
    using BookRate.BLL.ViewModels.Contributor;
    using BookRate.BLL.ViewModels.Edition;
    using BookRate.BLL.ViewModels.Genre;
    using BookRate.BLL.ViewModels.Narrative;
    using BookRate.BLL.ViewModels.Role;
    using BookRate.BLL.ViewModels.Serie;
    using BookRate.BLL.ViewModels.Setting;
    using BookRate.DAL.DTO.Book;
    using BookRate.DAL.DTO.BookEdition;
    using BookRate.DAL.DTO.Contributor;
    using BookRate.DAL.DTO.Edition;
    using BookRate.DAL.DTO.Genre;
    using BookRate.DAL.DTO.Narrative;
    using BookRate.DAL.DTO.Serie;
    using BookRate.DAL.DTO.Setting;
    using BookRate.DAL.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreListModel>();
            CreateMap<CreateGenreDTO, Genre>();
            CreateMap<UpdateGenreDTO, Genre>();
            CreateMap<Genre, GenreViewModel>();


            CreateMap<Contributor, ContributorViewModel>();
            CreateMap<CreateContributorDTO, Contributor>();
            CreateMap<UpdateContributorDTO, Contributor>();
            CreateMap<Contributor, ContributorListModel>();


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

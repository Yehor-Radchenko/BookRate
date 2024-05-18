namespace BookRate.Profile
{
    using AutoMapper;
    using BookRate.BLL.ViewModels.Book;
    using BookRate.BLL.ViewModels.Contributor;
    using BookRate.BLL.ViewModels.Edition;
    using BookRate.BLL.ViewModels.Genre;
    using BookRate.BLL.ViewModels.Narrative;
    using BookRate.BLL.ViewModels.Reward;
    using BookRate.BLL.ViewModels.Role;
    using BookRate.BLL.ViewModels.Serie;
    using BookRate.BLL.ViewModels.Setting;
    using BookRate.DAL.DTO.Book;
    using BookRate.DAL.DTO.BookEdition;
    using BookRate.DAL.DTO.Contributor;
    using BookRate.DAL.DTO.Edition;
    using BookRate.DAL.DTO.Genre;
    using BookRate.DAL.DTO.Narrative;
    using BookRate.DAL.DTO.NarrativeRevard;
    using BookRate.DAL.DTO.Reward;
    using BookRate.DAL.DTO.Role;
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

            CreateMap<Contributor, ContributorViewModel>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.ContributorRoles.Select(cr => cr.Role)));
            CreateMap<CreateContributorDTO, Contributor>();
            CreateMap<UpdateContributorDTO, Contributor>();
            CreateMap<Contributor, ContributorListModel>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.ContributorRoles.Select(cr => cr.Role)));

            CreateMap<Role, RoleViewModel>();
            CreateMap<CreateRoleDTO, Role>();
            CreateMap<UpdateRoleDTO, Role>();

            CreateMap<Edition, EditionViewModel>();
            CreateMap<CreateEditionDTO, Edition>();
            CreateMap<UpdateEditionDTO, Edition>();

            CreateMap<Setting, SettingViewModel>();
            CreateMap<CreateSettingDTO, Setting>();
            CreateMap<UpdateSettingDTO, Setting>();
            CreateMap<Setting, SettingListModel>();

            CreateMap<Reward, RewardViewModel>();
            CreateMap<CreateRewardDTO, Reward>();
            CreateMap<UpdateRewardDTO, Reward>();
            CreateMap<Reward, RewardListModel>();

            CreateMap<CreateNarrativeRewardDTO, NarrativeReward>()
                .ForMember(dest => dest.Narrative, opt => opt.Ignore())
                .ForMember(dest => dest.NarrativeId, opt => opt.Ignore());

            CreateMap<Serie, SerieViewModel>();
            CreateMap<CreateSerieDTO, Serie>();
            CreateMap<UpdateSerieDTO, Serie>();

            CreateMap<Narrative, NarrativeViewModel>();
            CreateMap<CreateNarrativeDTO, Narrative>()
                .ForMember(dest => dest.Genres, opt => opt.Ignore())
                .ForMember(dest => dest.Settings, opt => opt.Ignore())
                .ForMember(dest => dest.NarrativeContributorRoles, opt => opt.Ignore())
                .ForMember(dest => dest.NarrativeRewards, opt => opt.Ignore());
            CreateMap<UpdateNarrativeDTO, Narrative>();

            CreateMap<Book, BookViewModel>();
            CreateMap<CreateBookDTO, Book>();
            CreateMap<UpdateBookDTO, Book>();

            CreateMap<CreateBookEditionDTO, BookEdition>()
                .ForMember(dest => dest.BookId, opt => opt.Ignore());
        }
    }
}

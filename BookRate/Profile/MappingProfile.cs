using BookRate.BLL.ViewModels.User;

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
            CreateMap<CreateContributorDTO, Contributor>()
                .ForMember(dest => dest.ContributorRoles, opt => opt.MapFrom(src => src.RolesId.Select(roleId => new ContributorRole { RoleId = roleId })))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.GenresId.Select(genreId => new Genre { Id = genreId })))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo != null && src.Photo.Length > 0 ? new Photo { Data = src.Photo } : null));

            CreateMap<UpdateContributorDTO, Contributor>()
                .ForMember(dest => dest.ContributorRoles, opt => opt.Ignore())
                .ForMember(dest => dest.Genres, opt => opt.Ignore())
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo != null && src.Photo.Length > 0 ? new Photo { Data = src.Photo } : null));
            CreateMap<Contributor, ContributorListModel>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.ContributorRoles.Select(cr => cr.Role)));
            CreateMap<Contributor, AuthorListModel>();

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

            CreateMap<Narrative, NarrativeViewModel>()
                .ForMember(dest => dest.Contributors, opt => opt.MapFrom(src =>
                    src.NarrativeContributorRoles.Select(ncr => ncr.ContributorRole.Contributor).Distinct()))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
                .ForMember(dest => dest.Settings, opt => opt.MapFrom(src => src.Settings))
                .ForMember(dest => dest.Rewards, opt => opt.MapFrom(src => src.NarrativeRewards));

            CreateMap<CreateNarrativeDTO, Narrative>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Genres, opt => opt.Ignore())
                .ForMember(dest => dest.Settings, opt => opt.Ignore())
                .ForMember(dest => dest.NarrativeContributorRoles, opt => opt.Ignore())
                .ForMember(dest => dest.NarrativeRewards, opt => opt.Ignore());
            CreateMap<UpdateNarrativeDTO, Narrative>()
                .ForMember(dest => dest.Genres, opt => opt.Ignore())
                .ForMember(dest => dest.Settings, opt => opt.Ignore())
                .ForMember(dest => dest.NarrativeContributorRoles, opt => opt.Ignore())
                .ForMember(dest => dest.NarrativeRewards, opt => opt.Ignore());
            CreateMap<Narrative, NarrativeListModel>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
                    src.NarrativeContributorRoles
                        .Where(ncr => ncr.ContributorRole.Role.Name == "Author")
                        .Select(ncr => ncr.ContributorRole.Contributor)
                        .FirstOrDefault()));

            CreateMap<Book, BookViewModel>();
            CreateMap<CreateBookDTO, Book>();
            CreateMap<UpdateBookDTO, Book>();

            CreateMap<CreateBookEditionDTO, BookEdition>()
                .ForMember(dest => dest.BookId, opt => opt.Ignore());

            CreateMap<BLL.ViewModels.User.User, User>().ReverseMap();

        }
    }
}

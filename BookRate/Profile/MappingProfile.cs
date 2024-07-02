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
            CreateMap<GenreDto, Genre>();
            CreateMap<Genre, GenreViewModel>();

            CreateMap<Contributor, ContributorViewModel>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.ContributorRoles.Select(cr => cr.Role)))
                .ForMember(dest => dest.PhotoBase64, opt => opt.MapFrom(src => src.Photo != null ? Convert.ToBase64String(src.Photo.Data) : null));
            CreateMap<ContributorDto, Contributor>()
                .ForMember(dest => dest.ContributorRoles, opt => opt.Ignore())
                .ForMember(dest => dest.Genres, opt => opt.Ignore())
                .ForMember(dest => dest.Photo, opt => opt.Ignore());
            CreateMap<Contributor, ContributorDto>()
                .ForMember(dest => dest.RolesId, opt => opt.MapFrom(src => src.ContributorRoles.Select(cr => cr.RoleId)))
                .ForMember(dest => dest.GenresId, opt => opt.MapFrom(src => src.Genres.Select(g => g.Id)))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo != null ? src.Photo.Data : null));
            CreateMap<Contributor, ContributorListModel>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.ContributorRoles.Select(cr => cr.Role)));
            CreateMap<Contributor, AuthorListModel>();

            CreateMap<Role, RoleViewModel>();
            CreateMap<RoleDto, Role>();

            CreateMap<Edition, EditionViewModel>();
            CreateMap<EditionDto, Edition>();

            CreateMap<Setting, SettingViewModel>();
            CreateMap<SettingDto, Setting>();
            CreateMap<Setting, SettingListModel>();

            CreateMap<Reward, RewardViewModel>();
            CreateMap<RewardDto, Reward>();
            CreateMap<Reward, RewardListModel>();

            CreateMap<NarrativeRewardDto, NarrativeReward>()
                .ForMember(dest => dest.Narrative, opt => opt.Ignore())
                .ForMember(dest => dest.NarrativeId, opt => opt.Ignore());

            CreateMap<Serie, SerieViewModel>();
            CreateMap<SerieDto, Serie>();

            CreateMap<Narrative, NarrativeViewModel>()
                .ForMember(dest => dest.Contributors, opt => opt.MapFrom(src =>
                    src.NarrativeContributorRoles.Select(ncr => ncr.ContributorRole.Contributor).Distinct()))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
                .ForMember(dest => dest.Settings, opt => opt.MapFrom(src => src.Settings))
                .ForMember(dest => dest.Rewards, opt => opt.MapFrom(src => src.NarrativeRewards));
            CreateMap<NarrativeDto, Narrative>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
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

            CreateMap<Reward, NarrativeRewardViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<NarrativeReward, NarrativeRewardViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Reward.Name));

            CreateMap<Book, BookViewModel>();
            CreateMap<BookDto, Book>();

            CreateMap<BookEditionDto, BookEdition>()
                .ForMember(dest => dest.BookId, opt => opt.Ignore());

            CreateMap<BLL.ViewModels.User.UserViewModel, User>().ReverseMap();
        }
    }
}

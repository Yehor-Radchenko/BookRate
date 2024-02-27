using AutoMapper;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using System;

namespace BookRate.BLL.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookEdition, BookEditionDTO>();
            CreateMap<Commentary, CommentaryDTO>();
            CreateMap<CommentaryLike, CommentaryLikeDTO>();
            CreateMap<Contributor, ContributorDTO>();
            CreateMap<Edition, EditionDTO>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<Narrative, NarrativeDTO>();
            CreateMap<NarrativeRevard, NarrativeRevardDTO>();
            CreateMap<Rate, RateDTO>();
            CreateMap<Revard, RevardDTO>();
            CreateMap<ReviewLike, ReviewLikeDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<Serie, SerieDTO>();
            CreateMap<Setting, SettingDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}

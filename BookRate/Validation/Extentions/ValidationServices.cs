using BookRate.DAL.DTO.Book;
using BookRate.DAL.DTO.BookEdition;
using BookRate.DAL.DTO.Commentary;
using BookRate.DAL.DTO.Contributor;
using BookRate.DAL.DTO.Edition;
using BookRate.DAL.DTO.Genre;
using BookRate.DAL.DTO.Narrative;
using BookRate.DAL.DTO.NarrativeRevard;
using BookRate.DAL.DTO.Review;
using BookRate.DAL.DTO.Reward;
using BookRate.DAL.DTO.Role;
using BookRate.DAL.DTO.Serie;
using BookRate.DAL.DTO.Setting;
using BookRate.DAL.DTO.Shelf;
using BookRate.DAL.DTO.User;
using FluentValidation;
using System;

namespace BookRate.Validation.Extentions
{
    public static class ValidationServices
    {
        public static IServiceCollection AddValidationServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<BaseGenreDTO>, GenreValidator>();
            services.AddScoped<IValidator<BaseBookEditionDTO>, BookEditionValidator>();
            services.AddScoped<IValidator<BaseBookDTO>, BookValidator>();
            services.AddScoped<IValidator<BaseCommentaryDTO>, CommentaryValidator>();
            services.AddScoped<IValidator<BaseContributorDTO>, ContributorValidator>();
            services.AddScoped<IValidator<BaseEditionDTO>, EditionValidator>();
            services.AddScoped<IValidator<BaseNarrativeRewardDTO>, NarrativeRewardValidator>();
            services.AddScoped<IValidator<BaseNarrativeDTO>, NarrativeValidator>();
            services.AddScoped<IValidator<BaseReviewDTO>, ReviewValidator>();
            services.AddScoped<IValidator<BaseRoleDTO>, RoleValidator>();
            services.AddScoped<IValidator<BaseRewardDTO>, RewardValidator>();
            services.AddScoped<IValidator<BaseSerieDTO>, SerieValidator>();
            services.AddScoped<IValidator<BaseSettingDTO>, SettingValidator>();
            services.AddScoped<IValidator<BaseShelfDTO>, ShelfValidator>();
            services.AddScoped<IValidator<BaseUserDTO>, UserValidator>();
            services.AddScoped <IValidator <byte[]>, PhotoValidator>();

            return services;
        }
    }
}

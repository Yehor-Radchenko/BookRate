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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookRate.Validation.Extentions
{
    public static class ValidationServices
    {
        public static IServiceCollection AddValidationServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GenreDto>, GenreValidator>();
            services.AddScoped<IValidator<BookEditionDto>, BookEditionValidator>();
            services.AddScoped<IValidator<BookDto>, BookValidator>();
            services.AddScoped<IValidator<CommentaryDto>, CommentaryValidator>();
            services.AddScoped<IValidator<ContributorDto>, ContributorValidator>();
            services.AddScoped<IValidator<EditionDto>, EditionValidator>();
            services.AddScoped<IValidator<NarrativeRewardDto>, NarrativeRewardValidator>();
            services.AddScoped<IValidator<NarrativeDto>, NarrativeValidator>();
            services.AddScoped<IValidator<ReviewDto>, ReviewValidator>();
            services.AddScoped<IValidator<RoleDto>, RoleValidator>();
            services.AddScoped<IValidator<RewardDto>, RewardValidator>();
            services.AddScoped<IValidator<SerieDto>, SerieValidator>();
            services.AddScoped<IValidator<SettingDto>, SettingValidator>();
            services.AddScoped<IValidator<ShelfDto>, ShelfValidator>();
            services.AddScoped<IValidator<UserDto>, UserValidator>();
            services.AddScoped <IValidator <IFormFile>, PhotoValidator>();

            return services;
        }
    }
}

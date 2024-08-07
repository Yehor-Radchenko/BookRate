﻿using BookRate.BLL.HelperServices;

using BookRate.BLL.Services;
using BookRate.BLL.Services.ServiceAbstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookRate.BLL.Extension
{
    public static class BLLServices
    {

        public static IServiceCollection AddBllServices(this IServiceCollection services, IConfiguration configuration)
        {      
            services.AddScoped<ContributorService>();
            services.AddScoped<GenreService>();
            services.AddScoped<NarrativeService>();
            services.AddScoped<RewardService>();
            services.AddScoped<RoleService>();
            services.AddScoped<SettingService>();
            services.AddScoped<JwtService>();
            services.AddScoped<UserService>();
            services.AddScoped<ReviewService>();
            services.AddScoped<ReviewLikeService>();
            services.AddScoped<BookService>();
             
            return services;
        }

    }

}

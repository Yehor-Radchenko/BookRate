using BookRate.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookRate.BLL.Extension
{
    public static class BLLServices
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<ContributorService>();
            services.AddScoped<GenreService>();
            services.AddScoped<NarrativeService>();
            services.AddScoped<RewardService>();
            services.AddScoped<RoleService>();
            services.AddScoped<SettingService>();
            return services;
        }
    }

}

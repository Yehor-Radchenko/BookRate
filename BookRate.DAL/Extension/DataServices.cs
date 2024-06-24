using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.EntityImplementations;
using BookRate.DAL.Repositories.IRepository;
using BookRate.DAL.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookRate.DAL.Extension
{
    public static class DataServices
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration builder)
        {
            DatabaseConfigurator.Configure(services, builder);
            services.AddScoped<IUnitOfWork, UnitOfWork>();   
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); 
 
        
            return services;
        }
    }
}

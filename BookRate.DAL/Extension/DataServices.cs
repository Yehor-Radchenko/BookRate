using BookRate.DAL.Context;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.EntityImplementations;
using BookRate.DAL.Repositories.IRepository;
using BookRate.DAL.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.Extension
{
    public static class DataServices
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services,IConfiguration builder)
        {

            services.AddDbContext<BookRateDbContext>(options =>
            {
                options.UseNpgsql(builder.GetConnectionString("DefaultDbConnection"));
            });
          

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));     
            
            return services;

        }
    }
}

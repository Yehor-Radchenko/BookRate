using BookRate.BLL.Services;
using BookRate.BLL.Services.IService;
using BookRate.DAL.Context;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.IRepository;
using BookRate.Profile;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<BookRateDbContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("DATABASE_CON_STRING") ?? throw new InvalidOperationException("Connection string not found.")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IContributorRepository, ContributorRepository>();
builder.Services.AddScoped<IContributorService, ContributorService>();

builder.Services.AddScoped<IEditionRepository, EditionRepository>();
builder.Services.AddScoped<IEditionService, EditionService>();

builder.Services.AddScoped<ISettingRepository, SettingRepository>();
builder.Services.AddScoped<ISettingService, SettingService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

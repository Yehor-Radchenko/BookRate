using BookRate.BLL.Services;
using BookRate.DAL.Context;
using BookRate.DAL.UoW;
using BookRate.Profile;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();

builder.Services.AddControllers();

builder.Services.AddDbContext<BookRateDbContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("DATABASE_CON_STRING") ?? throw new InvalidOperationException("Connection string not found.")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.AddScoped<GenreService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



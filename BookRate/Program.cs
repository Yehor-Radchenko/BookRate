using BookRate.BLL.Extension;
using BookRate.DAL.Context;
using BookRate.DAL.Extension;
using BookRate.DAL.UoW;
using BookRate.Middlware;
using BookRate.Profile;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();

builder.Services.AddControllers();

builder.Services.AddDbContext<BookRateDbContext>(options =>
builder.Services.AddAutoMapper(typeof(MappingProfile)));

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddDalServices(builder.Configuration);

builder.Services.AddBllServices();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();



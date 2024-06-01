using BookRate.BLL.Extension;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.DAL.Extension;
using BookRate.Middlware;
using BookRate.Profile;
using BookRate.Service.Services;
using BookRate.Validation.Extentions;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.DataProtection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();



Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
               

Log.Logger.Information("Start Project");

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDalServices(builder.Configuration);
builder.Services.AddBllServices();
builder.Services.AddValidationServices();

builder.Services.AddTransient(sp => new EmailService(Environment.GetEnvironmentVariable("MAILJET_API_KEY")!,
    Environment.GetEnvironmentVariable("MAILJET_API_SECRET")!));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


builder.Services.AddEndpointsApiExplorer();
builder.Host.UseSerilog();
builder.Services.AddSwaggerGen();

Log.Information("Total Services {count}: ", builder.Services.Count());

var app = builder.Build();

app.UseSerilogRequestLogging();

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



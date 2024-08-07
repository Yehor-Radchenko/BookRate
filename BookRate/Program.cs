using BookRate.BLL.Extension;
using BookRate.Common.Enums;
using BookRate.DAL.Context;
using BookRate.DAL.Extension;
using BookRate.DAL.Seed;
using BookRate.Filters;
using BookRate.Middlware;
using BookRate.Profile;
using BookRate.Validation.Extentions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();



Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();


Log.Logger.Information("Start Project");


builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDalServices(builder.Configuration);
builder.Services.AddBllServices(builder.Configuration);
builder.Services.AddValidationServices();

builder.Services.AddTransient(sp => new EmailService(Environment.GetEnvironmentVariable("MAILJET_API_KEY")!,
Environment.GetEnvironmentVariable("MAILJET_API_SECRET")!));

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["Token"];
            return Task.CompletedTask;
        }
    };

});

builder.Services.AddScoped<CheckApproachFilter>(provide => new CheckApproachFilter("true"));


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireRole("Admin");
    });
});


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

app.UseMiddleware<GlobalExceptionHandler>();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BookRateDbContext>();
    DataSeed.SeedDatabase(context);
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

using HousesPapon.API.Filters;
using HousesPapon.Application;
using HousesPapon.Infrastructure;
using HousesPapon.Infrastructure.Migrations;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
    builder.WebHost.UseUrls($"http://*:{port}");
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(config =>
{
    config.Cookie.Name = "houses-papon-session";
    config.Cookie.HttpOnly = true;

    if (builder.Environment.IsProduction())
        config.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    else
        config.Cookie.SecurePolicy = CookieSecurePolicy.None;

    config.Cookie.SameSite = SameSiteMode.None;
    config.ExpireTimeSpan = TimeSpan.FromMinutes(10080);
    config.SlidingExpiration = true;
    config.Cookie.Path = "/";
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCorsSegura", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddRouting(x => x.LowercaseUrls = true);
builder.Services.AddMvc(f => f.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment()) 
    app.UseHttpsRedirection();

app.UseCors("PoliticaCorsSegura");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await MigrateDatabase();

app.Run();

async Task MigrateDatabase()
{
    await using var scope = app.Services.CreateAsyncScope();
    await DataBaseMigration.MigrateDatabase(scope.ServiceProvider);
}
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.RateLimiting;
using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var isLocal = env == "Development" || env == "Local";

var authority = isLocal
    ? "http://localhost:8080/realms/LeagueRealm"
    : "https://auth.myleaguebuilder.com/realms/LeagueRealm";


builder.Services.AddAuthentication()
                .AddKeycloakJwtBearer(
                    serviceName: "keycloak",
                    realm: "LeagueRealm",
                    configureOptions: options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.Audience = "league-builder-api";
                        options.Authority = authority;
                        options.RequireHttpsMetadata = false;
                    });


// Add services to the container.
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddServiceDiscoveryDestinationResolver()
    .AddTransforms(transform =>
    {
        transform.AddRequestTransform(async context =>
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var token = await context.HttpContext.GetTokenAsync("access_token");

                if (!string.IsNullOrEmpty(token))
                {
                    context.ProxyRequest.Headers.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
            }
        });
    });

builder.Services.AddAuthorization();

builder.Services.AddCors(o => o.AddPolicy("CustomPolicy", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));


builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});

var app = builder.Build();

// Health check endpoint
app.MapGet("/healthz", () => Results.Ok("OK")).AllowAnonymous();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultEndpoints();

app.UseCors();
// Configure the HTTP request pipeline.
app.UseRateLimiter();

app.MapReverseProxy().RequireAuthorization();

app.Run();
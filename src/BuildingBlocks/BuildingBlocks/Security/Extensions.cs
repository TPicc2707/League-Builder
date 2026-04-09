using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Security;

public static class Extensions
{
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var isLocal = env == "Development" || env == "Local";

        var authority = isLocal
            ? "http://localhost:8080/realms/LeagueRealm"
            : "https://auth.myleaguebuilder.com/realms/LeagueRealm";

        services.AddAuthentication()
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

        return services;
    }
}

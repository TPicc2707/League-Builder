using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Security;

public static class Extensions
{
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication()
                .AddKeycloakJwtBearer(
                    serviceName: "keycloak",
                    realm: "LeagueRealm",
                    configureOptions: options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.Audience = "league-builder-api";
                        options.Authority = "http://localhost:8080/realms/LeagueRealm";
                        options.RequireHttpsMetadata = false;
                    });

        return services;
    }
}

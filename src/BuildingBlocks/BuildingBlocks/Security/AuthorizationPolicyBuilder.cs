using Keycloak.AuthServices.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Security;

public static class AuthorizationPolicyBuilder
{
    public static IServiceCollection AddKeycloakPolicies(this IServiceCollection services, string serviceName)
    {
        var authorizationBuilder = services.AddAuthorization().AddKeycloakAuthorization(options =>
        {
            options.RolesResource = "league-builder-client";
        }).AddAuthorizationBuilder();

        if (serviceName == ServiceName.LeagueService)
        {
            authorizationBuilder
            .AddPolicy(KeycloakPolicy.ReadLeaguePolicy, policy => policy.RequireResourceRoles(KeycloakRoles.ReadLeagueRole))
            .AddPolicy(KeycloakPolicy.CreateLeaguePolicy, policy => policy.RequireResourceRoles(KeycloakRoles.CreateLeagueRole))
            .AddPolicy(KeycloakPolicy.UpdateLeaguePolicy, policy => policy.RequireResourceRoles(KeycloakRoles.UpdateLeagueRole))
            .AddPolicy(KeycloakPolicy.DeleteLeaguePolicy, policy => policy.RequireResourceRoles(KeycloakRoles.DeleteLeagueRole))
            .AddPolicy(KeycloakPolicy.SupportLeaguePolicy, policy => policy.RequireResourceRoles(KeycloakRoles.SupportLeagueRole));
        }

        if(serviceName == ServiceName.TeamService)
        {
            authorizationBuilder
            .AddPolicy(KeycloakPolicy.ReadTeamPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.ReadTeamRole))
            .AddPolicy(KeycloakPolicy.CreateTeamPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.CreateTeamRole))
            .AddPolicy(KeycloakPolicy.UpdateTeamPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.UpdateTeamRole))
            .AddPolicy(KeycloakPolicy.DeleteTeamPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.DeleteTeamRole))
            .AddPolicy(KeycloakPolicy.SupportTeamPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.SupportTeamRole));

        }

        if (serviceName == ServiceName.PlayerService)
        {
            authorizationBuilder
            .AddPolicy(KeycloakPolicy.ReadPlayerPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.ReadPlayerRole))
            .AddPolicy(KeycloakPolicy.CreatePlayerPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.CreatePlayerRole))
            .AddPolicy(KeycloakPolicy.UpdatePlayerPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.UpdatePlayerRole))
            .AddPolicy(KeycloakPolicy.DeletePlayerPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.DeletePlayerRole))
            .AddPolicy(KeycloakPolicy.SupportPlayerPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.SupportPlayerRole));
        }

        if (serviceName == ServiceName.SeasonService)
        {
            authorizationBuilder
            .AddPolicy(KeycloakPolicy.ReadSeasonPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.ReadSeasonRole))
            .AddPolicy(KeycloakPolicy.CreateSeasonPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.CreateSeasonRole))
            .AddPolicy(KeycloakPolicy.UpdateSeasonPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.UpdateSeasonRole))
            .AddPolicy(KeycloakPolicy.DeleteSeasonPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.DeleteSeasonRole))
            .AddPolicy(KeycloakPolicy.SupportSeasonPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.SupportSeasonRole));

        }

        if(serviceName == ServiceName.StandingsService)
        {
            authorizationBuilder
            .AddPolicy(KeycloakPolicy.ReadStandingsPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.ReadStandingsRole))
            .AddPolicy(KeycloakPolicy.CreateStandingsPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.CreateStandingsRole))
            .AddPolicy(KeycloakPolicy.UpdateStandingsPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.UpdateStandingsRole))
            .AddPolicy(KeycloakPolicy.DeleteStandingsPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.DeleteStandingsRole))
            .AddPolicy(KeycloakPolicy.SupportStandingsPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.SupportStandingsRole));
        }

        if (serviceName == ServiceName.GameService)
        {
            authorizationBuilder
            .AddPolicy(KeycloakPolicy.ReadGamePolicy, policy => policy.RequireResourceRoles(KeycloakRoles.ReadGameRole))
            .AddPolicy(KeycloakPolicy.CreateGamePolicy, policy => policy.RequireResourceRoles(KeycloakRoles.CreateGameRole))
            .AddPolicy(KeycloakPolicy.UpdateGamePolicy, policy => policy.RequireResourceRoles(KeycloakRoles.UpdateGameRole))
            .AddPolicy(KeycloakPolicy.DeleteGamePolicy, policy => policy.RequireResourceRoles(KeycloakRoles.DeleteGameRole))
            .AddPolicy(KeycloakPolicy.SupportGamePolicy, policy => policy.RequireResourceRoles(KeycloakRoles.SupportGameRole));

        }

        if(serviceName == ServiceName.StatService)
        {
            authorizationBuilder
            .AddPolicy(KeycloakPolicy.ReadStatPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.ReadStatRole))
            .AddPolicy(KeycloakPolicy.CreateStatPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.CreateStatRole))
            .AddPolicy(KeycloakPolicy.UpdateStatPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.UpdateStatRole))
            .AddPolicy(KeycloakPolicy.DeleteStatPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.DeleteStatRole))
            .AddPolicy(KeycloakPolicy.SupportStatPolicy, policy => policy.RequireResourceRoles(KeycloakRoles.SupportStatRole));

        }

        return services;
    }
}

namespace League.API.Leagues.UpdateLeagueSettings;

public record UpdateLeagueSettingsRequest(Guid Id, int TotalGamesPerSeason, int TotalPlayoffTeams);

public record UpdateLeagueSettingsResponse(bool IsSuccess);


public class UpdateLeagueSettingsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/leagues/settings", async (UpdateLeagueSettingsRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateLeagueSettingsCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateLeagueSettingsCommand>();

            return Results.Ok(response);
        })
        .WithName("UpdateLeagueSettings")
        .Produces<UpdateLeagueSettingsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Update League Settings")
        .WithDescription("Update League Settings")
        .RequireAuthorization(KeycloakPolicy.UpdateLeaguePolicy);
    }
}

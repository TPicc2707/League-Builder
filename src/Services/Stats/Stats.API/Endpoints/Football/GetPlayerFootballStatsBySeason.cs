namespace Stats.API.Endpoints.Football;

//public record GetPlayerFootballStatsBySeasonRequest(Guid PlayerId, Guid SeasonId);
public record GetPlayerFootballStatsBySeasonResponse(IEnumerable<FootballStatsDto> FootballStats);


public class GetPlayerFootballStatsBySeason : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/footballstats/player/season/{playerId}/{seasonId}", async (Guid playerId, Guid seasonId, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayerFootballStatsBySeasonQuery(playerId, seasonId));

            var response = result.Adapt<GetPlayerFootballStatsBySeasonResponse>();

            return Results.Ok(response);
        })
       .WithName("GetPlayerFootballStatsBySeason")
       .Produces<GetPlayerFootballStatsBySeasonResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Player Football Stats By Season")
       .WithDescription("Get Player Football Stats By Season")
       .RequireAuthorization(KeycloakPolicy.ReadStatPolicy);
    }
}

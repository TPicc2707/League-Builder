namespace Stats.API.Endpoints.Baseball;

//public record GetPlayerBaseballStatsBySeasonRequest(Guid PlayerId, Guid SeasonId);
public record GetPlayerBaseballStatsBySeasonResponse(IEnumerable<BaseballStatsDto> BaseballStats);


public class GetPlayerBaseballStatsBySeason : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballstats/player/season/{playerId}/{seasonId}", async (Guid playerId, Guid seasonId, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayerBaseballStatsBySeasonQuery(playerId, seasonId));

            var response = result.Adapt<GetPlayerBaseballStatsBySeasonResponse>();

            return Results.Ok(response);
        })
       .WithName("GetPlayerBaseballStatsBySeason")
       .Produces<GetPlayerBaseballStatsBySeasonResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Player Baseball Stats By Season")
       .WithDescription("Get Player Baseball Stats By Season")
       .RequireAuthorization(KeycloakPolicy.ReadStatPolicy);
    }
}

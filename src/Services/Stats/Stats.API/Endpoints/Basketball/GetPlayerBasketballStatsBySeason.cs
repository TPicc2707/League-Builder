namespace Stats.API.Endpoints.Basketball;

//public record GetPlayerBasketballStatsBySeasonRequest(Guid PlayerId, Guid SeasonId);
public record GetPlayerBasketballStatsBySeasonResponse(IEnumerable<BasketballStatsDto> BasketballStats);


public class GetPlayerBasketballStatsBySeason : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basketballstats/player/season/{playerId}/{seasonId}", async (Guid playerId, Guid seasonId, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayerBasketballStatsBySeasonQuery(playerId, seasonId));

            var response = result.Adapt<GetPlayerBasketballStatsBySeasonResponse>();

            return Results.Ok(response);
        })
       .WithName("GetPlayerBasketballStatsBySeason")
       .Produces<GetPlayerBasketballStatsBySeasonResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Player Basketball Stats By Season")
       .WithDescription("Get Player Basketball Stats By Season");
    }
}

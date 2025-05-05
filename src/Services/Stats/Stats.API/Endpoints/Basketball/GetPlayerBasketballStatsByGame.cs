namespace Stats.API.Endpoints.Basketball;

//public record GetPlayerBasketballStatsByGameRequest(Guid PlayerId, Guid GameId);
public record GetPlayerBasketballStatsByGameResponse(BasketballStatsDto BasketballStats);


public class GetPlayerBasketballStatsByGame : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basketballstats/player/game/{playerId}/{gameId}", async (Guid playerId, Guid gameId, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayerBasketballStatsByGameQuery(playerId, gameId));

            var response = result.Adapt<GetPlayerBasketballStatsByGameResponse>();

            return Results.Ok(response);
        })
       .WithName("GetPlayerBasketballStatsByGame")
       .Produces<GetPlayerBasketballStatsByGameResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Player Basketball Stats By Game")
       .WithDescription("Get Player Basketball Stats By Game");

    }
}

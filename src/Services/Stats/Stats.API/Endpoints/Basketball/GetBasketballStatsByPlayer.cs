namespace Stats.API.Endpoints.Basketball;

//public record GetBasketballStatsByPlayerRequest(Guid PlayerId);
public record GetBasketballStatsByPlayerResponse(IEnumerable<BasketballStatsDto> BasketballStats);


public class GetBasketballStatsByPlayer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basketballstats/player/{playerId}", async (Guid playerId, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketballStatsByPlayerQuery(playerId));

            var response = result.Adapt<GetBasketballStatsByPlayerResponse>();

            return Results.Ok(response);
        })
       .WithName("GetBasketballStatsByPlayer")
       .Produces<GetBasketballStatsByPlayerResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Basketball Stats By Player")
       .WithDescription("Get Basketball Stats By Player");
    }
}

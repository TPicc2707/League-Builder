namespace Stats.API.Endpoints.Basketball;

//public record GetBasketballStatsByLeagueRequest(Guid LeagueId);
public record GetBasketballStatsByLeagueResponse(IEnumerable<BasketballStatsDto> BasketballStats);


public class GetBasketballStatsByLeague : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basketballstats/league/{leagueId}", async (Guid leagueId, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketballStatsByLeagueQuery(leagueId));

            var response = result.Adapt<GetBasketballStatsByLeagueResponse>();

            return Results.Ok(response);
        })
       .WithName("GetBasketballStatsByLeague")
       .Produces<GetBasketballStatsByLeagueResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Basketball Stats By League")
       .WithDescription("Get Basketball Stats By League");
    }
}

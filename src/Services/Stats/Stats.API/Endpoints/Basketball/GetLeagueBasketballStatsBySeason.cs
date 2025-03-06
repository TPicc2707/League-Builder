namespace Stats.API.Endpoints.Basketball;

//public record GetLeagueBasketballStatsBySeasonRequest(Guid LeagueId, Guid SeasonId);
public record GetLeagueBasketballStatsBySeasonResponse(IEnumerable<BasketballStatsDto> BasketballStats);


public class GetLeagueBasketballStatsBySeason : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basketballstats/league/season/{leagueId}/{seasonId}", async (Guid leagueId, Guid seasonId, ISender sender) =>
        {
            var result = await sender.Send(new GetLeagueBasketballStatsBySeasonQuery(leagueId, seasonId));

            var response = result.Adapt<GetLeagueBasketballStatsBySeasonResponse>();

            return Results.Ok(response);
        })
       .WithName("GetLeagueBasketballStatsBySeason")
       .Produces<GetLeagueBasketballStatsBySeasonResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get League Basketball Stats By Season")
       .WithDescription("Get League Basketball Stats By Season");
    }
}

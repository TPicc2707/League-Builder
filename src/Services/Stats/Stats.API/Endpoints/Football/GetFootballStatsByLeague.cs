namespace Stats.API.Endpoints.Football;

//public record GetFootballStatsByLeagueRequest(Guid LeagueId);
public record GetFootballStatsByLeagueResponse(IEnumerable<FootballStatsDto> FootballStats);


public class GetFootballStatsByLeague : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/footballstats/league/{leagueId}", async (Guid leagueId, ISender sender) =>
        {
            var result = await sender.Send(new GetFootballStatsByLeagueQuery(leagueId));

            var response = result.Adapt<GetFootballStatsByLeagueResponse>();

            return Results.Ok(response);
        })
       .WithName("GetFootballStatsByLeague")
       .Produces<GetFootballStatsByLeagueResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Football Stats By League")
       .WithDescription("Get Football Stats By League");
    }
}

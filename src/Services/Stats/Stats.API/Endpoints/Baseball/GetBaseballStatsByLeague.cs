namespace Stats.API.Endpoints.Baseball;

//public record GetBaseballStatsByLeagueRequest(Guid LeagueId);
public record GetBaseballStatsByLeagueResponse(IEnumerable<BaseballStatsDto> BaseballStats);

public class GetBaseballStatsByLeague : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballstats/league/{leagueId}", async (Guid leagueId, ISender sender) =>
        {
            var result = await sender.Send(new GetBaseballStatsByLeagueQuery(leagueId));

            var response = result.Adapt<GetBaseballStatsByLeagueResponse>();

            return Results.Ok(response);
        })
       .WithName("GetBaseballStatsByLeague")
       .Produces<GetBaseballStatsByLeagueResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Baseball Stats By League")
       .WithDescription("Get Baseball Stats By League");
    }
}

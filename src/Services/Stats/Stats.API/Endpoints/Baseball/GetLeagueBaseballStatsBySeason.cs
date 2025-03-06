namespace Stats.API.Endpoints.Baseball;

//public record GetLeagueBaseballStatsBySeasonRequest(Guid LeagueId, Guid SeasonId);
public record GetLeagueBaseballStatsBySeasonResponse(IEnumerable<BaseballStatsDto> BaseballStats);


public class GetLeagueBaseballStatsBySeason : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballstats/league/season/{leagueId}/{seasonId}", async (Guid leagueId, Guid seasonId, ISender sender) =>
        {
            var result = await sender.Send(new GetLeagueBaseballStatsBySeasonQuery(leagueId, seasonId));

            var response = result.Adapt<GetLeagueBaseballStatsBySeasonResponse>();

            return Results.Ok(response);
        })
       .WithName("GetLeagueBaseballStatsBySeason")
       .Produces<GetLeagueBaseballStatsBySeasonResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get League Baseball Stats By Season")
       .WithDescription("Get League Baseball Stats By Season");
    }
}

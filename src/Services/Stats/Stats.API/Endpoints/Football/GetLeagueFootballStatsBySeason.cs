namespace Stats.API.Endpoints.Football;

//public record GetLeagueFootballStatsBySeasonRequest(Guid LeagueId, Guid SeasonId);
public record GetLeagueFootballStatsBySeasonResponse(IEnumerable<FootballStatsDto> FootballStats);


public class GetLeagueFootballStatsBySeason : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/footballstats/league/season/{leagueId}/{seasonId}", async (Guid leagueId, Guid seasonId, ISender sender) =>
        {
            var result = await sender.Send(new GetLeagueFootballStatsBySeasonQuery(leagueId, seasonId));

            var response = result.Adapt<GetLeagueFootballStatsBySeasonResponse>();

            return Results.Ok(response);
        })
       .WithName("GetLeagueFootballStatsBySeason")
       .Produces<GetLeagueFootballStatsBySeasonResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get League Football Stats By Season")
       .WithDescription("Get League Football Stats By Season");
    }
}

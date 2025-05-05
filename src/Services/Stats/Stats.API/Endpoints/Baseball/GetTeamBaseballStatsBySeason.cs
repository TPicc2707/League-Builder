namespace Stats.API.Endpoints.Baseball;

//public record GetTeamBaseballStatsBySeasonRequest(Guid SeasonId, Guid GameId);
public record GetTeamBaseballStatsBySeasonResponse(IEnumerable<BaseballStatsDto> BaseballStats);


public class GetTeamBaseballStatsBySeason : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballstats/team/season/{teamId}/{seasonId}", async (Guid teamId, Guid seasonId, ISender sender) =>
        {
            var result = await sender.Send(new GetTeamBaseballStatsBySeasonQuery(teamId, seasonId));

            var response = result.Adapt<GetTeamBaseballStatsBySeasonResponse>();

            return Results.Ok(response);
        })
       .WithName("GetTeamBaseballStatsBySeason")
       .Produces<GetTeamBaseballStatsBySeasonResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Team Baseball Stats By Season")
       .WithDescription("Get Team Baseball Stats By Season");
    }
}

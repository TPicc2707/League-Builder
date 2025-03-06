namespace Stats.API.Endpoints.Football;

//public record GetTeamFootballStatsByGameRequest(Guid TeamId, Guid GameId);
public record GetTeamFootballStatsByGameResponse(IEnumerable<FootballStatsDto> FootballStats);


public class GetTeamFootballStatsByGame : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/footballstats/team/game/{teamId}/{gameId}", async (Guid teamId, Guid gameId, ISender sender) =>
        {
            var result = await sender.Send(new GetTeamFootballStatsByGameQuery(teamId, gameId));

            var response = result.Adapt<GetTeamFootballStatsByGameResponse>();

            return Results.Ok(response);
        })
       .WithName("GetTeamFootballStatsByGame")
       .Produces<GetTeamFootballStatsByGameResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Team Football Stats By Game")
       .WithDescription("Get Team Football Stats By Game");


    }
}

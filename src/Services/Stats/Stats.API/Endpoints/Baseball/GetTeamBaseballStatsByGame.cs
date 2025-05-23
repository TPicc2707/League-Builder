namespace Stats.API.Endpoints.Baseball;

//public record GetTeamBaseballStatsByGameRequest(Guid TeamId, Guid GameId);
public record GetTeamBaseballStatsByGameResponse(IEnumerable<BaseballStatsDto> BaseballStats);


public class GetTeamBaseballStatsByGame : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballstats/team/game/{teamId}/{gameId}", async (Guid teamId, Guid gameId, ISender sender) =>
        {
            var result = await sender.Send(new GetTeamBaseballStatsByGameQuery(teamId, gameId));

            var response = result.Adapt<GetTeamBaseballStatsByGameResponse>();

            return Results.Ok(response);
        })
       .WithName("GetTeamBaseballStatsByGame")
       .Produces<GetTeamBaseballStatsByGameResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Team Baseball Stats By Game")
       .WithDescription("Get Team Baseball Stats By Game")
       .RequireAuthorization(KeycloakPolicy.ReadStatPolicy);


    }
}

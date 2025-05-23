namespace Stats.API.Endpoints.Baseball;

//public record GetPlayerBaseballStatsByGameRequest(Guid PlayerId, Guid GameId);
public record GetPlayerBaseballStatsByGameResponse(BaseballStatsDto BaseballStat);


public class GetPlayerBaseballStatsByGame : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballstats/player/game/{playerId}/{gameId}", async (Guid playerId, Guid gameId, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayerBaseballStatsByGameQuery(playerId, gameId));

            var response = result.Adapt<GetPlayerBaseballStatsByGameResponse>();

            return Results.Ok(response);
        })
       .WithName("GetPlayerBaseballStatsByGame")
       .Produces<GetPlayerBaseballStatsByGameResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Player Baseball Stats By Game")
       .WithDescription("Get Player Baseball Stats By Game")
       .RequireAuthorization(KeycloakPolicy.ReadStatPolicy);

    }
}
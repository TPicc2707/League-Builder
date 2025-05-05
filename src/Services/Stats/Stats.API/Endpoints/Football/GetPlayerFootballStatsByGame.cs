namespace Stats.API.Endpoints.Football;

//public record GetPlayerFootballStatsByGameRequest(Guid PlayerId, Guid GameId);
public record GetPlayerFootballStatsByGameResponse(FootballStatsDto FootballStats);


public class GetPlayerFootballStatsByGame : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/footballstats/player/game/{playerId}/{gameId}", async (Guid playerId, Guid gameId, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayerFootballStatsByGameQuery(playerId, gameId));

            var response = result.Adapt<GetPlayerFootballStatsByGameResponse>();

            return Results.Ok(response);
        })
       .WithName("GetPlayerFootballStatsByGame")
       .Produces<GetPlayerFootballStatsByGameResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Player Football Stats By Game")
       .WithDescription("Get Player Football Stats By Game");

    }
}

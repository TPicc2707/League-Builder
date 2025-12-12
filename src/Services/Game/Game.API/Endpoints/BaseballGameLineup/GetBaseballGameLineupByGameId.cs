namespace Game.API.Endpoints.BaseballGameLineup;

public record GetBaseballGameLineupByGameIdResponse(GameLineupDto GameLineup);

public class GetBaseballGameLineupByGameId : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballgamelineups/{gameid}/{teamId}", async (Guid gameId, Guid teamId, ISender sender) =>
        {
            var result = await sender.Send(new GetBaseballGameLineupByGameIdQuery(gameId, teamId));

            var response = result.Adapt<GetBaseballGameLineupByGameIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBaseballGameLineupByGameId")
        .Produces<GetBaseballGameLineupByGameIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Get Baseball Game Lineup By GameId")
        .WithDescription("Get Baseball Game Lineup By GameId")
        .RequireAuthorization(KeycloakPolicy.ReadGamePolicy);
    }
}

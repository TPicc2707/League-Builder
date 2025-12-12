namespace Game.API.Endpoints.BaseballGameLineup;

public record AnyBaseballGameLineupByGameIdResponse(bool IsLineupCreated);

public class AnyBaseballGameLineupByGameId : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballgamelineups/game/{gameid}/{teamId}", async (Guid gameId, Guid teamId, ISender sender) =>
        {
            var result = await sender.Send(new AnyBaseballGameLineupByGameIdQuery(gameId, teamId));

            var response = result.Adapt<AnyBaseballGameLineupByGameIdResponse>();

            return Results.Ok(response);

        })
        .WithName("AnyBaseballGameLineupByGameId")
        .Produces<AnyBaseballGameLineupByGameIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Any Baseball Game Lineup By Game Id")
        .WithDescription("Any Baseball Game Lineup By Game Id")
        .RequireAuthorization(KeycloakPolicy.ReadGamePolicy);
    }
}

namespace Game.API.Endpoints.BaseballGameLineup;

public record UpdateBaseballGameLineupRequest(GameLineupDto GameLineup);
public record UpdateBaseballGameLineupResponse(bool IsSuccess);

public class UpdateBaseballGameLineup : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/baseballgamelineups", async (UpdateBaseballGameLineupRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateBaseballGameLineupCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateBaseballGameLineupResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateBaseballGameLineup")
        .Produces<GetBaseballGameLineupByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Baseball Game Lineup")
        .WithDescription("Update Baseball Game Lineup")
        .RequireAuthorization(KeycloakPolicy.UpdateGamePolicy);
    }
}

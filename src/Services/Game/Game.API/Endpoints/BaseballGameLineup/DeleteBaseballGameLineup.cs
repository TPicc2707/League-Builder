
namespace Game.API.Endpoints.BaseballGameLineup;

public record DeleteBaseballGameLineupResponse(bool IsSuccess);

public class DeleteBaseballGameLineup : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/baseballgamelineups/{id}", async(Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBaseballGameLineupCommand(id));

            var response = result.Adapt<DeleteBaseballGameLineupResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteBaseballGameLineup")
        .Produces<DeleteBaseballGameLineupResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Baseball Game Lineup")
        .WithDescription("Delete Baseball Game Lineup")
        .RequireAuthorization(KeycloakPolicy.DeleteGamePolicy);
    }
}

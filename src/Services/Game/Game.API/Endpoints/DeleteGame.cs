namespace Game.API.Endpoints;

//public record DeleteGameRequest(Guid Id);
public record DeleteGameResponse(bool IsSuccess);

public class DeleteGame : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/games/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteGameCommand(id));

            var response = result.Adapt<DeleteGameResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteGame")
        .Produces<DeleteGameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Game")
        .WithDescription("Delete Game")
        .RequireAuthorization(KeycloakPolicy.DeleteGamePolicy);
    }
}

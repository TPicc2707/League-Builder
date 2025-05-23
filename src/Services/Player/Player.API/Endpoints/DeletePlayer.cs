namespace Player.API.Endpoints;

//public record DeletePlayerRequest(Guid Id);
public record DeletePlayerResponse(bool IsSuccess);


public class DeletePlayer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/players/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeletePlayerCommand(id));

            var response = result.Adapt<DeletePlayerResponse>();

            return Results.Ok(response);
        })
        .WithName("DeletePlayer")
        .Produces<DeletePlayerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Player")
        .WithDescription("Delete Player")
        .RequireAuthorization(KeycloakPolicy.DeletePlayerPolicy);
    }
}

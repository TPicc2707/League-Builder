namespace Player.API.Endpoints;

public record UpdatePlayerRequest(PlayerDto Player);
public record UpdatePlayerResponse(bool IsSuccess);


public class UpdatePlayer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/players", async (UpdatePlayerRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdatePlayerCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdatePlayerResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdatePlayer")
        .Produces<UpdatePlayerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Player")
        .WithDescription("Update Player");
    }
}

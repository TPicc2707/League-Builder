namespace Player.API.Endpoints;

public record CreatePlayerRequest(PlayerDto Player);
public record CreatePlayerResponse(Guid Id);


public class CreatePlayer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/players", async (CreatePlayerRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreatePlayerCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreatePlayerResponse>();

            return Results.Created($"/players/{response.Id}", response);
        })
       .WithName("CreatePlayer")
       .Produces<CreatePlayerResponse>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Create Player")
       .WithDescription("Create Player")
       .RequireAuthorization(KeycloakPolicy.CreatePlayerPolicy);
    }
}

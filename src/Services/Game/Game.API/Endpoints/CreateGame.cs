namespace Game.API.Endpoints;

public record CreateGameRequest(GameDto Game);

public record CreateGameResponse(Guid Id);

public class CreateGame : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/games", async (CreateGameRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateGameCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateGameResponse>();

            return Results.Created($"/games/{response.Id}", response);
        })
       .WithName("CreateGame")
       .Produces<CreateGameResponse>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Create Game")
       .WithDescription("Create Game")
       .RequireAuthorization(KeycloakPolicy.CreateGamePolicy);
    }
}

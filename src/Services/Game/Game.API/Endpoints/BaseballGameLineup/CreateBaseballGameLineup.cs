namespace Game.API.Endpoints.BaseballGameLineup;

public record CreateBaseballGameLineupRequest(GameLineupDto GameLineup);

public record CreateBaseballGameLineupResponse(Guid Id);

public class CreateBaseballGameLineup : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/baseballgamelineups", async (CreateBaseballGameLineupRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateBaseballGameLineupCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateBaseballGameLineupResponse>();

            return Results.Created($"/baseballGameLineups/{response.Id}", response);
        })
       .WithName("CreateBaseballGameLineup")
       .Produces<CreateBaseballGameLineupResponse>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Create Baseball Game Lineup")
       .WithDescription("Create Baseball Game Lineup")
       .RequireAuthorization(KeycloakPolicy.CreateGamePolicy);
    }
}

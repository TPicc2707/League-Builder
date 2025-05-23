namespace Stats.API.Endpoints.Basketball;

public record CreateBasketballStatsRequest(BasketballStatsDto BasketballStats);
public record CreateBasketballStatsResponse(Guid Id);


public class CreateBasketballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basketballstats", async (CreateBasketballStatsRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateBasketballStatsCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateBasketballStatsResponse>();

            return Results.Created($"/basketballstats/{response.Id}", response);
        })
       .WithName("CreateBasketballStats")
       .Produces<CreateBasketballStatsResponse>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Create Basketball Stats")
       .WithDescription("Create Basketball Stats")
       .RequireAuthorization(KeycloakPolicy.CreateStatPolicy);
    }
}

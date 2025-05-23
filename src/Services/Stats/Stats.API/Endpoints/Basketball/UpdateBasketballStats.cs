namespace Stats.API.Endpoints.Basketball;

public record UpdateBasketballStatsRequest(BasketballStatsDto BasketballStats);
public record UpdateBasketballStatsResponse(bool IsSuccess);


public class UpdateBasketballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/basketballstats", async (UpdateBasketballStatsRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateBasketballStatsCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateBasketballStatsResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateBasketballStats")
        .Produces<UpdateBasketballStatsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Basketball Stats")
        .WithDescription("Update Basketball Stats")
        .RequireAuthorization(KeycloakPolicy.UpdateStatPolicy);
    }
}

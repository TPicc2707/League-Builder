namespace Stats.API.Endpoints.Basketball;

//public record DeleteBasketballStatsRequest(Guid Id);
public record DeleteBasketballStatsResponse(bool IsSuccess);

public class DeleteBasketballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basketballstats/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBasketballStatsCommand(id));

            var response = result.Adapt<DeleteBasketballStatsResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteBasketballStats")
        .Produces<DeleteBasketballStatsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Basketball Stats")
        .WithDescription("Delete Basketball Stats");
    }
}

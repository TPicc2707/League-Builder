namespace Stats.API.Endpoints.Baseball;

//public record DeletePlayerRequest(Guid Id);
public record DeleteBaseballStatsResponse(bool IsSuccess);


public class DeleteBaseballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/baseballstats/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBaseballStatsCommand(id));

            var response = result.Adapt<DeleteBaseballStatsResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteBaseballStats")
        .Produces<DeleteBaseballStatsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Baseball Stats")
        .WithDescription("Delete Baseball Stats");
    }
}

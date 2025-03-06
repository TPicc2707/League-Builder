namespace Stats.API.Endpoints.Football;

//public record DeleteFootballStatsRequest(Guid Id);
public record DeleteFootballStatsResponse(bool IsSuccess);


public class DeleteFootballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/footballstats/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteFootballStatsCommand(id));

            var response = result.Adapt<DeleteFootballStatsResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteFootballStats")
        .Produces<DeleteFootballStatsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Football Stats")
        .WithDescription("Delete Football Stats");
    }
}

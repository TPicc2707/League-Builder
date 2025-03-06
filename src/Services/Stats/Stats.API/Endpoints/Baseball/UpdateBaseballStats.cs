namespace Stats.API.Endpoints.Baseball;

public record UpdateBaseballStatsRequest(BaseballStatsDto BaseballStat);
public record UpdateBaseballStatsResponse(bool IsSuccess);


public class UpdateBaseballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/baseballstats", async (UpdateBaseballStatsRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateBaseballStatsCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateBaseballStatsResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateBaseballStats")
        .Produces<UpdateBaseballStatsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Baseball Stats")
        .WithDescription("Update Baseball Stats");
    }
}

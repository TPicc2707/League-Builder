namespace Stats.API.Endpoints.Baseball;

public record CreateBaseballStatsRequest(BaseballStatsDto BaseballStats);
public record CreateBaseballStatsResponse(Guid Id);


public class CreateBaseballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/baseballstats", async (CreateBaseballStatsRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateBaseballStatsCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateBaseballStatsResponse>();

            return Results.Created($"/baseballstats/{response.Id}", response);
        })
       .WithName("CreateBaseballStats")
       .Produces<CreateBaseballStatsResponse>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Create Baseball Stats")
       .WithDescription("Create Baseball Stats");
    }
}

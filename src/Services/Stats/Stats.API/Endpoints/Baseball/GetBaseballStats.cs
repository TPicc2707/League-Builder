namespace Stats.API.Endpoints.Baseball;

//public record GetBaseballStatsRequest(PaginationRequest PaginationRequest);
public record GetBaseballStatsResponse(PaginatedResult<BaseballStatsDto> BaseballStats);


public class GetBaseballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballstats", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetBaseballStatsQuery(request));

            var response = result.Adapt<GetBaseballStatsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBaseballStats")
        .Produces<GetBaseballStatsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Baseball Stats")
        .WithDescription("Get Baseball Stats");
    }
}

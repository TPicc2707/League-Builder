namespace Stats.API.Endpoints.Football;

//public record GetFootballStatsRequest(PaginationRequest PaginationRequest);
public record GetFootballStatsResponse(PaginatedResult<FootballStatsDto> FootballStats);


public class GetFootballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/footballstats", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetFootballStatsQuery(request));

            var response = result.Adapt<GetFootballStatsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetFootballStats")
        .Produces<GetFootballStatsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Football Stats")
        .WithDescription("Get Football Stats");
    }
}

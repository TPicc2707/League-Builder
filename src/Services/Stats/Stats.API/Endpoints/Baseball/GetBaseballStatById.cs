namespace Stats.API.Endpoints.Baseball;

//public record GetBaseballStatByIdRequest(Guid Id);
public record GetBaseballStatByIdResponse(BaseballStatsDto BaseballStat);

public class GetBaseballStatById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballstats/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetBaseballStatByIdQuery(id));

            var response = result.Adapt<GetBaseballStatByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBaseballStatById")
        .Produces<GetBaseballStatByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Baseball Stat By Id")
        .WithDescription("Get Baseball Stat By Id");
    }
}

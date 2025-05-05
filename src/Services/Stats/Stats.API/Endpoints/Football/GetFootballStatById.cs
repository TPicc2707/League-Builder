namespace Stats.API.Endpoints.Football;

//public record GetFootballStatByIdRequest(Guid Id);
public record GetFootballStatByIdResponse(FootballStatsDto FootballStats);


public class GetFootballStatById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/footballstats/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetFootballStatByIdQuery(id));

            var response = result.Adapt<GetFootballStatByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetFootballStatById")
        .Produces<GetFootballStatByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Football Stat By Id")
        .WithDescription("Get Football Stat By Id");
    }
}

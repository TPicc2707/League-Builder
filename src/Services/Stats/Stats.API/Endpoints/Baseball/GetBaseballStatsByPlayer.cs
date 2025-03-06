namespace Stats.API.Endpoints.Baseball;

//public record GetBaseballStatsByPlayerRequest(Guid PlayerId);
public record GetBaseballStatsByPlayerResponse(IEnumerable<BaseballStatsDto> BaseballStats);


public class GetBaseballStatsByPlayer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballstats/player/{playerId}", async (Guid playerId, ISender sender) =>
        {
            var result = await sender.Send(new GetBaseballStatsByPlayerQuery(playerId));

            var response = result.Adapt<GetBaseballStatsByPlayerResponse>();

            return Results.Ok(response);
        })
       .WithName("GetBaseballStatsByPlayer")
       .Produces<GetBaseballStatsByPlayerResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Baseball Stats By Player")
       .WithDescription("Get Baseball Stats By Player");
    }
}

namespace Stats.API.Endpoints.Football;

//public record GetFootballStatsByPlayerRequest(Guid PlayerId);
public record GetFootballStatsByPlayerResponse(IEnumerable<FootballStatsDto> FootballStats);


public class GetFootballStatsByPlayer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/footballstats/player/{playerId}", async (Guid playerId, ISender sender) =>
        {
            var result = await sender.Send(new GetFootballStatsByPlayerQuery(playerId));

            var response = result.Adapt<GetFootballStatsByPlayerResponse>();

            return Results.Ok(response);
        })
       .WithName("GetFootballStatsByPlayer")
       .Produces<GetFootballStatsByPlayerResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Football Stats By Player")
       .WithDescription("Get Football Stats By Player")
       .RequireAuthorization(KeycloakPolicy.ReadStatPolicy);
    }
}

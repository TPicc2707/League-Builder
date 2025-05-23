namespace Stats.API.Endpoints.Basketball;

//public record GetTeamBasketballStatsBySeasonRequest(Guid SeasonId, Guid GameId);
public record GetTeamBasketballStatsBySeasonResponse(IEnumerable<BasketballStatsDto> BasketballStats);


public class GetTeamBasketballStatsBySeason : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basketballstats/team/season/{teamId}/{seasonId}", async (Guid teamId, Guid seasonId, ISender sender) =>
        {
            var result = await sender.Send(new GetTeamBasketballStatsBySeasonQuery(teamId, seasonId));

            var response = result.Adapt<GetTeamBasketballStatsBySeasonResponse>();

            return Results.Ok(response);
        })
       .WithName("GetTeamBasketballStatsBySeason")
       .Produces<GetTeamBasketballStatsBySeasonResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Team Basketball Stats By Season")
       .WithDescription("Get Team Basketball Stats By Season")
       .RequireAuthorization(KeycloakPolicy.ReadStatPolicy);
    }
}

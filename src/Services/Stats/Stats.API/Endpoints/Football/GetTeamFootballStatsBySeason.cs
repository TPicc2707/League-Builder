using Stats.API.Endpoints.Basketball;

namespace Stats.API.Endpoints.Football;

//public record GetTeamFootballStatsBySeasonRequest(Guid SeasonId, Guid GameId);
public record GetTeamFootballStatsBySeasonResponse(IEnumerable<FootballStatsDto> FootballStats);


public class GetTeamFootballStatsBySeason : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/footballstats/team/season/{teamId}/{seasonId}", async (Guid teamId, Guid seasonId, ISender sender) =>
        {
            var result = await sender.Send(new GetTeamFootballStatsBySeasonQuery(teamId, seasonId));

            var response = result.Adapt<GetTeamFootballStatsBySeasonResponse>();

            return Results.Ok(response);
        })
       .WithName("GetTeamFootballStatsBySeason")
       .Produces<GetTeamBasketballStatsBySeasonResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Team Football Stats By Season")
       .WithDescription("Get Team Football Stats By Season")
       .RequireAuthorization(KeycloakPolicy.ReadStatPolicy);
    }
}

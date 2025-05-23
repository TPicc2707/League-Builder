namespace Stats.API.Endpoints.Football;

//public record GetFootballStatsByTeamRequest(Guid TeamId);
public record GetFootballStatsByTeamResponse(IEnumerable<FootballStatsDto> FootballStats);


public class GetFootballStatsByTeam : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/footballstats/team/{teamId}", async (Guid teamId, ISender sender) =>
        {
            var result = await sender.Send(new GetFootballStatsByTeamQuery(teamId));

            var response = result.Adapt<GetFootballStatsByTeamResponse>();

            return Results.Ok(response);
        })
       .WithName("GetFootballStatsByTeam")
       .Produces<GetFootballStatsByTeamResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Football Stats By Team")
       .WithDescription("Get Football Stats By Team")
       .RequireAuthorization(KeycloakPolicy.ReadStatPolicy);
    }
}

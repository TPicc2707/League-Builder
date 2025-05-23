namespace Standings.API.Endpoints;

//public record GetStandingsByTeamRequest(Guid TeamId);
public record GetStandingsByTeamResponse(IEnumerable<StandingsDto> Standings);

public class GetStandingsByTeam : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/standings/team/{teamId}", async (Guid teamId, ISender sender) =>
        {
            var result = await sender.Send(new GetStandingsByTeamQuery(teamId));

            var response = result.Adapt<GetStandingsByTeamResponse>();

            return Results.Ok(response);
        })
        .WithName("GetStandingsByTeam")
        .Produces<GetStandingsByTeamResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Standings By Team")
        .WithDescription("Get Standings By Team")
        .RequireAuthorization(KeycloakPolicy.ReadStandingsPolicy);
    }
}

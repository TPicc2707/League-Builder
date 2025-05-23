namespace Standings.API.Endpoints;

//public record GetStandingsByLeagueRequest(Guid LeagueId);
public record GetStandingsByLeagueResponse(IEnumerable<StandingsDto> Standings);

public class GetStandingsByLeague : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/standings/league/{leagueId}", async (Guid leagueId, ISender sender) =>
        {
            var result = await sender.Send(new GetStandingsByLeagueQuery(leagueId));

            var response = result.Adapt<GetStandingsByLeagueResponse>();

            return Results.Ok(response);
        })
        .WithName("GetStandingsByLeague")
        .Produces<GetStandingsByLeagueResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Standings By League")
        .WithDescription("Get Standings By League")
        .RequireAuthorization(KeycloakPolicy.ReadStandingsPolicy);
    }
}

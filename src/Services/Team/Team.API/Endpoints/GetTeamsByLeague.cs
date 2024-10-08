namespace Team.API.Endpoints;

//public record GetTeamsByLeagueRequest(Guid LeagueId);
public record GetTeamsByLeagueResponse(IEnumerable<TeamDto> Teams);

public class GetTeamsByLeague : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/teams/league/{leagueId}", async (Guid leagueId, ISender sender) =>
        {
            var result = await sender.Send(new GetTeamsByLeagueQuery(leagueId));

            var response = result.Adapt<GetTeamsByLeagueResponse>();

            return Results.Ok(response);
        })
        .WithName("GetTeamsByLeague")
        .Produces<GetTeamsByLeagueResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Teams By League")
        .WithDescription("Get Teams By League");
    }
}

namespace Game.API.Endpoints;

//public record GetGamesByLeagueRequest(Guid LeagueId);
public record GetGamesByLeagueResponse(IEnumerable<GameDto> Games);

public class GetGamesByLeague : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/games/league/{leagueId}", async (Guid leagueId, ISender sender) =>
        {
            var result = await sender.Send(new GetGamesByLeagueQuery(leagueId));

            var response = result.Adapt<GetGamesByLeagueResponse>();

            return Results.Ok(response);
        })
        .WithName("GetGamesByLeague")
        .Produces<GetGamesByLeagueResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Games By League")
        .WithDescription("Get Games By League")
        .RequireAuthorization(KeycloakPolicy.ReadGamePolicy);
    }
}

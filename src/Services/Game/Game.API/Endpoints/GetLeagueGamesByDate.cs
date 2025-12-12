namespace Game.API.Endpoints;

public record GetLeagueGamesByDateResponse(IEnumerable<GameDto> Games);

public class GetLeagueGamesByDate : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/games/league/date/{leagueId}/{date}", async (Guid leagueId, DateTime date, ISender sender) =>
        {
            var result = await sender.Send(new GetLeagueGamesByDateQuery(leagueId, date));

            var response = result.Adapt<GetLeagueGamesByDateResponse>();

            return Results.Ok(response);
        })
        .WithName("GetLeagueGamesByDate")
        .Produces<GetLeagueGamesByDateResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get League Games By Date")
        .WithDescription("Get League Games By Date")
        .RequireAuthorization(KeycloakPolicy.ReadGamePolicy);
    }
}

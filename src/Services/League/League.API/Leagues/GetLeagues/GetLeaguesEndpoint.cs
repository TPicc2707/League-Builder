namespace League.API.Leagues.GetLeagues;

public record GetLeaguesRequest(int? PageNumber = 1, int? PageSize = 10);
public record GetLeaguesResponse(IEnumerable<Models.League> Leagues);


public class GetLeaguesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/leagues", async ([AsParameters] GetLeaguesRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetLeaguesQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetLeaguesResponse>();

            return Results.Ok(response);
        })
        .WithName("GetLeagues")
        .Produces<GetLeaguesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Leagues")
        .WithDescription("Get Leagues")
        .RequireAuthorization(KeycloakPolicy.ReadLeaguePolicy);
    }
}

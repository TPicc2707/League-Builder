namespace Game.API.Endpoints;

//public record GetGamesRequest(PaginationRequest PaginationRequest);
public record GetGamesResponse(PaginatedResult<GameDto> Games);

public class GetGames : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/games", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetGamesQuery(request));

            var response = result.Adapt<GetGamesResponse>();

            return Results.Ok(response);
        })
        .WithName("GetGames")
        .Produces<GetGamesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Games")
        .WithDescription("Get Games")
        .RequireAuthorization(KeycloakPolicy.ReadGamePolicy);
    }
}

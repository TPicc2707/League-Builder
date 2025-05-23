namespace Player.API.Endpoints;

//public record GetPlayersRequest(PaginationRequest PaginationRequest);
public record GetPlayersResponse(PaginatedResult<PlayerDto> Players);


public class GetPlayers : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/players", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayersQuery(request));

            var response = result.Adapt<GetPlayersResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPlayers")
        .Produces<GetPlayersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Players")
        .WithDescription("Get Players")
        .RequireAuthorization(KeycloakPolicy.ReadPlayerPolicy);
    }
}

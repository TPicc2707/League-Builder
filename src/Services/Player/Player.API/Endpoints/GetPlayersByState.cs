namespace Player.API.Endpoints;

//public record GetPlayersByStateRequest(string State);
public record GetPlayersByStateResponse(IEnumerable<PlayerDto> Players);

public class GetPlayersByState : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/players/states/{states}", async (string states, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayersByStateQuery(states));

            var response = result.Adapt<GetPlayersByStateResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPlayersByState")
        .Produces<GetPlayersByStateResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Players By State")
        .WithDescription("Get Players By State")
        .RequireAuthorization(KeycloakPolicy.ReadPlayerPolicy);
    }
}

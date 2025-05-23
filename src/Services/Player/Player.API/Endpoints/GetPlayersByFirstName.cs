namespace Player.API.Endpoints;

//public record GetPlayersByFirstNameRequest(string FirstName);
public record GetPlayersByFirstNameResponse(IEnumerable<PlayerDto> Players);

public class GetPlayersByFirstName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/players/firstname/{name}", async (string name, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayersByFirstNameQuery(name));

            var response = result.Adapt<GetPlayersByFirstNameResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPlayersByFirstName")
        .Produces<GetPlayersByFirstNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Players By First Name")
        .WithDescription("Get Players By First Name")
        .RequireAuthorization(KeycloakPolicy.ReadPlayerPolicy);
    }
}

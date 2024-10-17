namespace Player.API.Endpoints;

//public record GetPlayersByLastNameRequest(string LastName);
public record GetPlayersByLastNameResponse(IEnumerable<PlayerDto> Players);

public class GetPlayersByLastName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/players/lastname/{name}", async (string name, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayersByLastNameQuery(name));

            var response = result.Adapt<GetPlayersByLastNameResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPlayersByLastName")
        .Produces<GetPlayersByLastNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Players By Last Name")
        .WithDescription("Get Players By Last Name");
    }
}

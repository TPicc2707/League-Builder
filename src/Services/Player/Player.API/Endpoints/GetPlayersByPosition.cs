namespace Player.API.Endpoints;

//public record GetPlayersByPositionRequest(string Position);
public record GetPlayersByPositionResponse(IEnumerable<PlayerDto> Players);

public class GetPlayersByPosition : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/players/position/{position}", async (string position, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayersByPositionQuery(position));

            var response = result.Adapt<GetPlayersByPositionResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPlayersByPosition")
        .Produces<GetPlayersByPositionResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Players By Position")
        .WithDescription("Get Players By Position");
    }
}

namespace Player.API.Endpoints;

//public record GetPlayerByIdRequest(Guid Id);
public record GetPlayerByIdResponse(PlayerDto Player);

public class GetPlayerById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/players/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayerByIdQuery(id));

            var response = result.Adapt<GetPlayerByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPlayerById")
        .Produces<GetPlayerByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Player By Id")
        .WithDescription("Get Player By Id")
        .RequireAuthorization(KeycloakPolicy.ReadPlayerPolicy);
    }
}

namespace Game.API.Endpoints;

//public record GetGameByIdRequest(Guid Id);
public record GetGameByIdResponse(GameDto Game);

public class GetGameById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/games/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetGameByIdQuery(id));

            var response = result.Adapt<GetGameByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetGameById")
        .Produces<GetGameByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Game By Id")
        .WithDescription("Get Game By Id")
        .RequireAuthorization(KeycloakPolicy.ReadGamePolicy);
    }
}

namespace Game.API.Endpoints.BaseballGameLineup;

public record GetBaseballGameLineupByIdResponse(GameLineupDto GameLineup);


public class GetBaseballGameLineupById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballgamelineups/{id}", async(Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetBaseballGameLineupByIdQuery(id));

            var response = result.Adapt<GetBaseballGameLineupByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBaseballGameLineupById")
        .Produces<GetBaseballGameLineupByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Baseball Game Lineup By Id")
        .WithDescription("Get Baseball Game Lineup By Id")
        .RequireAuthorization(KeycloakPolicy.ReadGamePolicy);
    }
}

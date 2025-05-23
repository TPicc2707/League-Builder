namespace League.API.Leagues.DeleteLeague;

//public record DeleteLeagueRequest(Guid Id);
public record DeleteLeagueResponse(bool IsSuccess);

public class DeleteLeagueEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/leagues/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteLeagueCommand(id));

            var response = result.Adapt<DeleteLeagueResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteLeague")
        .Produces<DeleteLeagueResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete League")
        .WithDescription("Delete League")
        .RequireAuthorization(KeycloakPolicy.DeleteLeaguePolicy);
    }
}

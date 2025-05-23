namespace Standings.API.Endpoints;

//public record DeleteStandingsRequest(Guid Id);
public record DeleteStandingsResponse(bool IsSuccess);

public class DeleteStandings : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/standings/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteStandingsCommand(id));

            var response = result.Adapt<DeleteStandingsResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteStandings")
        .Produces<DeleteStandingsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Standings")
        .WithDescription("Delete Standings")
        .RequireAuthorization(KeycloakPolicy.DeleteStandingsPolicy);
    }
}

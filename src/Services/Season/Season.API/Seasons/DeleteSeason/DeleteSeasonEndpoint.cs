namespace Season.API.Seasons.DeleteSeason;

//public record DeleteSeasonRequest(Guid Id);
public record DeleteSeasonResponse(bool IsSuccess);


public class DeleteSeasonEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/seasons/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteSeasonCommand(id));

            var response = result.Adapt<DeleteSeasonResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteSeason")
        .Produces<DeleteSeasonResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Season")
        .WithDescription("Delete Season")
        .RequireAuthorization(KeycloakPolicy.DeleteSeasonPolicy);
    }
}

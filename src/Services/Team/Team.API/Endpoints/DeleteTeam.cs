namespace Team.API.Endpoints;

//public record DeleteTeamRequest(Guid Id);
public record DeleteTeamResponse(bool IsSuccess);


public class DeleteTeam : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/teams/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteTeamCommand(id));

            var response = result.Adapt<DeleteTeamResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteTeam")
        .Produces<DeleteTeamResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Team")
        .WithDescription("Delete Team");
    }
}

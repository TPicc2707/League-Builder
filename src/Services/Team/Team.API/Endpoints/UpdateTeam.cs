namespace Team.API.Endpoints;

public record UpdateTeamRequest(TeamDto Team);
public record UpdateTeamResponse(bool IsSuccess);

public class UpdateTeam : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/teams", async (UpdateTeamRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateTeamCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateTeamResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateTeam")
        .Produces<UpdateTeamResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Team")
        .WithDescription("Update Team")
        .RequireAuthorization(KeycloakPolicy.UpdateTeamPolicy);
    }
}

namespace Team.API.Endpoints;

//public record GetTeamsByStateRequest(string State);
public record GetTeamsByStateResponse(IEnumerable<TeamDto> Teams);


public class GetTeamsByState : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/teams/state/{state}", async (string state, ISender sender) =>
        {
            var result = await sender.Send(new GetTeamsByStateQuery(state));

            var response = result.Adapt<GetTeamsByStateResponse>();

            return Results.Ok(response);
        })
        .WithName("GetTeamsByState")
        .Produces<GetTeamsByStateResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Teams By State")
        .WithDescription("Get Teams By State")
        .RequireAuthorization(KeycloakPolicy.ReadTeamPolicy);
    }
}

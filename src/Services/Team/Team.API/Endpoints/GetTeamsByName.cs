namespace Team.API.Endpoints;

//public record GetTeamsByNameRequest(string Name);
public record GetTeamsByNameResponse(IEnumerable<TeamDto> Teams);


public class GetTeamsByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/teams/name/{teamName}", async (string teamName, ISender sender) =>
        {
            var result = await sender.Send(new GetTeamsByNameQuery(teamName));

            var response = result.Adapt<GetTeamsByNameResponse>();

            return Results.Ok(response);
        })
        .WithName("GetTeamsByName")
        .Produces<GetTeamsByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Teams By Name")
        .WithDescription("Get Teams By Name")
        .RequireAuthorization(KeycloakPolicy.ReadTeamPolicy);
    }
}
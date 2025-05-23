namespace Game.API.Endpoints;

//public record GetGamesByTeamRequest(Guid TeamId);
public record GetGamesByTeamResponse(IEnumerable<GameDto> Games);

public class GetGamesByTeam : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/games/team/{teamId}", async (Guid teamId, ISender sender) =>
        {
            var result = await sender.Send(new GetGamesByTeamQuery(teamId));

            var response = result.Adapt<GetGamesByTeamResponse>();

            return Results.Ok(response);
        })
        .WithName("GetGamesByTeam")
        .Produces<GetGamesByTeamResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Games By Team")
        .WithDescription("Get Games By Team")
        .RequireAuthorization(KeycloakPolicy.ReadGamePolicy);
    }
}

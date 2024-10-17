namespace Player.API.Endpoints;

//public record GetPlayersByTeamRequest(Guid TeamId);
public record GetPlayersByTeamResponse(IEnumerable<PlayerDto> Players);

public class GetPlayersByTeam : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/players/team/{teamId}", async (Guid teamId, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayersByTeamQuery(teamId));

            var response = result.Adapt<GetPlayersByTeamResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPlayersByTeam")
        .Produces<GetPlayersByTeamResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Players By Team")
        .WithDescription("Get Players By Team");
    }
}

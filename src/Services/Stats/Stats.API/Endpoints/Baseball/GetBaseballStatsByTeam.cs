namespace Stats.API.Endpoints.Baseball;

//public record GetBaseballStatsByTeamRequest(Guid TeamId);
public record GetBaseballStatsByTeamResponse(IEnumerable<BaseballStatsDto> BaseballStats);


public class GetBaseballStatsByTeam : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baseballstats/team/{teamId}", async (Guid teamId, ISender sender) =>
        {
            var result = await sender.Send(new GetBaseballStatsByTeamQuery(teamId));

            var response = result.Adapt<GetBaseballStatsByTeamResponse>();

            return Results.Ok(response);
        })
       .WithName("GetBaseballStatsByTeam")
       .Produces<GetBaseballStatsByTeamResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Baseball Stats By Team")
       .WithDescription("Get Baseball Stats By Team");
    }
}

namespace Stats.API.Endpoints.Basketball;

//public record GetBasketballStatsByTeamRequest(Guid TeamId);
public record GetBasketballStatsByTeamResponse(IEnumerable<BasketballStatsDto> BasketballStats);

public class GetBasketballStatsByTeam : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basketballstats/team/{teamId}", async (Guid teamId, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketballStatsByTeamQuery(teamId));

            var response = result.Adapt<GetBasketballStatsByTeamResponse>();

            return Results.Ok(response);
        })
       .WithName("GetBasketballStatsByTeam")
       .Produces<GetBasketballStatsByTeamResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Basketball Stats By Team")
       .WithDescription("Get Basketball Stats By Team");
    }
}

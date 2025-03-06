namespace Stats.API.Endpoints.Basketball;

//public record GetTeamBasketballStatsByGameRequest(Guid TeamId, Guid GameId);
public record GetTeamBasketballStatsByGameResponse(IEnumerable<BasketballStatsDto> BasketballStats);


public class GetTeamBasketballStatsByGame : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basketballstats/team/game/{teamId}/{gameId}", async (Guid teamId, Guid gameId, ISender sender) =>
        {
            var result = await sender.Send(new GetTeamBasketballStatsByGameQuery(teamId, gameId));

            var response = result.Adapt<GetTeamBasketballStatsByGameResponse>();

            return Results.Ok(response);
        })
       .WithName("GetTeamBasketballStatsByGame")
       .Produces<GetTeamBasketballStatsByGameResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Get Team Basketball Stats By Game")
       .WithDescription("Get Team Basketball Stats By Game");


    }
}

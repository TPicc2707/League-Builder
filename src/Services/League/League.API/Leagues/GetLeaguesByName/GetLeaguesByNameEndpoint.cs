namespace League.API.Leagues.GetLeaguesByName;

//public record GetLeaguesByNameRequest();
public record GetLeaguesByNameResponse(IEnumerable<Models.League> Leagues);


public class GetLeaguesByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/leagues/name/{name}",
            async (string name, ISender sender) =>
            {
                var result = await sender.Send(new GetLeaguesByNameQuery(name));

                var response = result.Adapt<GetLeaguesByNameResponse>();

                return Results.Ok(response);
            })
        .WithName("GetLeaguesByName")
        .Produces<GetLeaguesByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Leagues By Name")
        .WithDescription("Get Leagues By Name");
    }
}

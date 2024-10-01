namespace League.API.Leagues.GetLeaguesBySport;

//public record GetLeaguesBySportRequest();
public record GetLeaguesBySportResponse(IEnumerable<Models.League> Leagues);

public class GetLeaguesBySportEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/leagues/sport/{sport}",
            async (string sport, ISender sender) =>
            {
                var result = await sender.Send(new GetLeaguesBySportQuery(sport));

                var response = result.Adapt<GetLeaguesBySportResponse>();

                return Results.Ok(response);
            })
        .WithName("GetLeaguesBySport")
        .Produces<GetLeaguesBySportResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Leagues By Sport")
        .WithDescription("Get Leagues By Sport");
    }
}

namespace Team.API.Endpoints;

//public record GetTeamsBySportRequest(string Sport);
public record GetTeamsBySportResponse(IEnumerable<TeamDto> Teams);


public class GetTeamsBySport : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/teams/sport/{sport}", async (string sport, ISender sender) =>
        {
            var result = await sender.Send(new GetTeamsBySportQuery(sport));

            var response = result.Adapt<GetTeamsBySportResponse>();

            return Results.Ok(response);
        })
        .WithName("GetTeamsBySport")
        .Produces<GetTeamsBySportResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Teams By Sport")
        .WithDescription("Get Teams By Sport");
    }
}

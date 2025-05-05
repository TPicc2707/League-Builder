namespace Standings.API.Endpoints;

public record UpdateStandingsRequest(StandingsDto Standings);
public record UpdateStandingsResponse(bool IsSuccess);


public class UpdateStandings : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/standings", async (UpdateStandingsRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateStandingsCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateStandingsResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateStandings")
        .Produces<UpdateStandingsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Standings")
        .WithDescription("Update Standings");
    }
}

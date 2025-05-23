namespace Stats.API.Endpoints.Football;

public record UpdateFootballStatsRequest(FootballStatsDto FootballStats);
public record UpdateFootballStatsResponse(bool IsSuccess);


public class UpdateFootballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/footballstats", async (UpdateFootballStatsRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateFootballStatsCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateFootballStatsResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateFootballStats")
        .Produces<UpdateFootballStatsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Football Stats")
        .WithDescription("Update Football Stats")
        .RequireAuthorization(KeycloakPolicy.UpdateStatPolicy);
    }
}

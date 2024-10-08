namespace League.API.Leagues.UpdateLeague;

public record UpdateLeagueRequest(Guid Id, string Name, string Sport, string Description, string EmailAddress, string ImageFile);

public record UpdateLeagueResponse(bool IsSuccess);

public class UpdateLeagueEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/leagues", async (UpdateLeagueRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateLeagueCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateLeagueResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateLeague")
        .Produces<UpdateLeagueResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Update League")
        .WithDescription("Update League");
    }
}
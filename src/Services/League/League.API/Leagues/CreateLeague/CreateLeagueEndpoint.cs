namespace League.API.Leagues.CreateLeague;

public record CreateLeagueRequest(string Name, string Sport, string Description, string EmailAddress, string ImageFile);

public record CreateLeagueResponse(Guid Id);

public class CreateLeagueEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/leagues", async (CreateLeagueRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateLeagueCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateLeagueResponse>();

            return Results.Created($"/leagues/{response.Id}", response);
        })
        .WithName("CreateLeague")
        .Produces<CreateLeagueResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create League")
        .WithDescription("Create League")
        .RequireAuthorization(KeycloakPolicy.CreateLeaguePolicy);
    }
}

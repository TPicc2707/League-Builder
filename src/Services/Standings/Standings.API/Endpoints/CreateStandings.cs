namespace Standings.API.Endpoints;

public record CreateStandingsRequest(StandingsDto Standings);

public record CreateStandingsResponse(Guid Id);

public class CreateStandings : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/standings", async (CreateStandingsRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateStandingsCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateStandingsResponse>();

            return Results.Created($"/standings/{response.Id}", response);
        })
       .WithName("CreateStandings")
       .Produces<CreateStandingsResponse>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Create Standings")
       .WithDescription("Create Standings");
    }
}

namespace Stats.API.Endpoints.Football;

public record CreateFootballStatsRequest(FootballStatsDto FootballStats);
public record CreateFootballStatsResponse(Guid Id);


public class CreateFootballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/footballstats", async (CreateFootballStatsRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateFootballStatsCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateFootballStatsResponse>();

            return Results.Created($"/footballstats/{response.Id}", response);
        })
       .WithName("CreateFootballStats")
       .Produces<CreateFootballStatsResponse>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Create Football Stats")
       .WithDescription("Create Football Stats");
    }
}

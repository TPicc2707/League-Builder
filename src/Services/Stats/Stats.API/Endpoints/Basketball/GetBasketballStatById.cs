namespace Stats.API.Endpoints.Basketball;

//public record GetBasketballStatByIdRequest(Guid Id);
public record GetBasketballStatByIdResponse(BasketballStatsDto BasketballStat);

public class GetBasketballStatById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basketballstats/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketballStatByIdQuery(id));

            var response = result.Adapt<GetBasketballStatByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBasketballStatById")
        .Produces<GetBasketballStatByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Basketball Stat By Id")
        .WithDescription("Get Basketball Stat By Id")
        .RequireAuthorization(KeycloakPolicy.ReadStatPolicy);
    }
}

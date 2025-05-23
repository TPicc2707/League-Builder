namespace Stats.API.Endpoints.Basketball;

//public record GetBasketballStatsRequest(PaginationRequest PaginationRequest);
public record GetBasketballStatsResponse(PaginatedResult<BasketballStatsDto> BasketballStats);

public class GetBasketballStats : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basketballstats", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketballStatsQuery(request));

            var response = result.Adapt<GetBasketballStatsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBasketballStats")
        .Produces<GetBasketballStatsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Basketball Stats")
        .WithDescription("Get Basketball Stats")
        .RequireAuthorization(KeycloakPolicy.ReadStatPolicy);
    }
}

namespace Season.API.Seasons.GetSeasons;

public record GetSeasonsRequest(int? PageNumber = 1, int? PageSize = 10);
public record GetSeasonsResponse(IEnumerable<Models.Season> Seasons);


public class GetSeasonsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/seasons", async ([AsParameters] GetSeasonsRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetSeasonsQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetSeasonsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetSeasons")
        .Produces<GetSeasonsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Seasons")
        .WithDescription("Get Seasons")
        .RequireAuthorization(KeycloakPolicy.ReadSeasonPolicy);
    }
}

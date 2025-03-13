namespace Standings.API.Endpoints;

//public record GetStandingsRequest(PaginationRequest PaginationRequest);
public record GetStandingsResponse(PaginatedResult<StandingsDto> Standings);

public class GetStandings : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/standings", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetStandingsQuery(request));

            var response = result.Adapt<GetStandingsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetStandings")
        .Produces<GetStandingsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Standings")
        .WithDescription("Get Standings");
    }
}

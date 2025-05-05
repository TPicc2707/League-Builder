namespace Season.API.Seasons.GetSeasonByYear;

//public record GetSeasonByYearRequest();
public record GetSeasonByYearResponse(Models.Season Season);


public class GetSeasonByYearEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/seasons/year/{year}", async (int year, ISender sender) =>
        {
            var result = await sender.Send(new GetSeasonByYearQuery(year));

            var response = result.Adapt<GetSeasonByYearResponse>();

            return Results.Ok(response);
        })
        .WithName("GetSeasonByYear")
        .Produces<GetSeasonByYearResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Season By Year")
        .WithDescription("Get Season By Year");
    }
}

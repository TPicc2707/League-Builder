namespace Season.API.Seasons.GetSeasonById;

//public record GetSeasonByIdRequest();
public record GetSeasonByIdResponse(Models.Season Season);


public class GetSeasonByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/seasons/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetSeasonByIdQuery(id));

            var response = result.Adapt<GetSeasonByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetSeasonById")
        .Produces<GetSeasonByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Season By Id")
        .WithDescription("Get Season By Id");
    }
}

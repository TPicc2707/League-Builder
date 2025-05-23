namespace League.API.Leagues.GetLeagueById;

//public record GetLeagueByIdRequest();
public record GetLeagueByIdResponse(Models.League League);


public class GetLeagueByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/leagues/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetLeagueByIdQuery(id));

            var response = result.Adapt<GetLeagueByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetLeagueById")
        .Produces<GetLeagueByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get League By Id")
        .WithDescription("Get League By Id")
        .RequireAuthorization(KeycloakPolicy.ReadLeaguePolicy);
    }
}

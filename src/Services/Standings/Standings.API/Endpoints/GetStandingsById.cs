namespace Standings.API.Endpoints;

//public record GetStandingsByIdRequest(Guid Id);
public record GetStandingsByIdResponse(StandingsDto Standings);

public class GetStandingsById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/standings/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetStandingsByIdQuery(id));

            var response = result.Adapt<GetStandingsByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetStandingsById")
        .Produces<GetStandingsByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Standings By Id")
        .WithDescription("Get Standings By Id")
        .RequireAuthorization(KeycloakPolicy.ReadStandingsPolicy);
    }
}

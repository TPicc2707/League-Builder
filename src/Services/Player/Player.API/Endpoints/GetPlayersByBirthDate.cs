namespace Player.API.Endpoints;

//public record GetPlayersByBirthDateRequest(DateTime BirthDate);
public record GetPlayersByBirthDateResponse(IEnumerable<PlayerDto> Players);


public class GetPlayersByBirthDate : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/players/by-birthdate/{birthDate}", async (DateTime birthDate, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayersByBirthDateQuery(birthDate));

            var response = result.Adapt<GetPlayersByBirthDateResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPlayersByBirthDate")
        .Produces<GetPlayersByBirthDateResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Players By Birth Date")
        .WithDescription("Get Players By Birth Date");
    }
}

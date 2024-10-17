namespace Player.API.Endpoints;

//public record GetPlayersBeforeBirthDateRequest(DateTime BirthDate);
public record GetPlayersBeforeBirthDateResponse(IEnumerable<PlayerDto> Players);

public class GetPlayersBeforeBirthDate : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/players/before-birthdate/{birthDate}", async (DateTime birthDate, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayersBeforeBirthDateQuery(birthDate));

            var response = result.Adapt<GetPlayersBeforeBirthDateResponse>();

            return Results.Ok(response);
        })
         .WithName("GetPlayersBeforeBirthDate")
         .Produces<GetPlayersBeforeBirthDateResponse>(StatusCodes.Status200OK)
         .ProducesProblem(StatusCodes.Status400BadRequest)
         .ProducesProblem(StatusCodes.Status404NotFound)
         .WithSummary("Get Players Before Birth Date")
         .WithDescription("Get Players Before Birth Date");
    }
}

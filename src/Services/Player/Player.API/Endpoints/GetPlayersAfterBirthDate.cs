namespace Player.API.Endpoints;

//public record GetPlayersAfterBirthDateRequest(DateTime BirthDate);
public record GetPlayersAfterBirthDateResponse(IEnumerable<PlayerDto> Players);


public class GetPlayersAfterBirthDate : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/players/after-birthdate/{birthDate}", async (DateTime birthDate, ISender sender) =>
        {
            var result = await sender.Send(new GetPlayersAfterBirthDateQuery(birthDate));

            var response = result.Adapt<GetPlayersAfterBirthDateResponse>();

            return Results.Ok(response);
        })
         .WithName("GetPlayersAfterBirthDate")
         .Produces<GetPlayersAfterBirthDateResponse>(StatusCodes.Status200OK)
         .ProducesProblem(StatusCodes.Status400BadRequest)
         .ProducesProblem(StatusCodes.Status404NotFound)
         .WithSummary("Get Players After Birth Date")
         .WithDescription("Get Players After Birth Date");
    }
}

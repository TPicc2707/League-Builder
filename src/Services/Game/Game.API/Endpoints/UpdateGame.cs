﻿namespace Game.API.Endpoints;

public record UpdateGameRequest(GameDto Game);
public record UpdateGameResponse(bool IsSuccess);


public class UpdateGame : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/games", async (UpdateGameRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateGameCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateGameResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateGame")
        .Produces<UpdateGameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Game")
        .WithDescription("Update Game");
    }
}

﻿namespace Team.API.Endpoints;

public record CreateTeamRequest(TeamDto Team);
public record CreateTeamResponse(Guid Id);

public class CreateTeam : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/teams", async (CreateTeamRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateTeamCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateTeamResponse>();

            return Results.Created($"/teams/{response.Id}", response);
        })
        .WithName("CreateTeam")
        .Produces<CreateTeamResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Team")
        .WithDescription("Create Team");
    }
}

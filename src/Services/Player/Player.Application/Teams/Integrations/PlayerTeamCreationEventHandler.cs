namespace Player.Application.Teams.Integrations;

public class PlayerTeamCreationEventHandler
    (ISender sender, ILogger<PlayerTeamCreationEventHandler> logger)
    : IHandleMessages<TeamCreationEvent>
{
    public async Task Handle(TeamCreationEvent message)
    {
        //TODO: Create new team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToCreateTeamCommand(message);
        await sender.Send(command);
    }

    private CreateTeamCommand MapToCreateTeamCommand(TeamCreationEvent message)
    {
        var teamDto = new TeamDto(
            Id: message.Id,
            TeamName: message.TeamName,
            Description: message.Description);

        return new CreateTeamCommand(teamDto);
    }
}

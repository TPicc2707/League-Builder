namespace Player.Application.Teams.Integrations;

public class PlayerTeamUpdatedEventHandler(ISender sender, ILogger<PlayerTeamUpdatedEventHandler> logger)
    : IHandleMessages<TeamUpdatedEvent>
{
    public async Task Handle(TeamUpdatedEvent message)
    {
        //TODO: Update league
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToUpdateTeamCommand(message);
        await sender.Send(command);
    }

    private UpdateTeamCommand MapToUpdateTeamCommand(TeamUpdatedEvent message)
    {
        var teamDto = new TeamDto(
            Id: message.Id,
            TeamName: message.TeamName,
            Description: message.Description);

        return new UpdateTeamCommand(teamDto);
    }
}

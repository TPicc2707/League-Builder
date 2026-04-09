namespace Stats.Application.Teams.Integrations;

public class StatsTeamCreationEventHandler
    (ISender sender, ILogger<StatsTeamCreationEventHandler> logger)
    : IHandleMessages<TeamCreationEvent>
{
    public async Task Handle(TeamCreationEvent message)
    {
        //TODO: Create new team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MaptoCreateTeamCommand(message);
        await sender.Send(command);
    }

    private CreateTeamCommand MaptoCreateTeamCommand(TeamCreationEvent message)
    {
        var teamDto = new TeamDto(
            Id: message.Id,
            TeamName: message.TeamName);

        return new CreateTeamCommand(teamDto);
    }
}
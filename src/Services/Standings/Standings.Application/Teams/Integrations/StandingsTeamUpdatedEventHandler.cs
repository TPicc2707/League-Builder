namespace Standings.Application.Teams.Integrations;

public class StandingsTeamUpdatedEventHandler(ISender sender, ILogger<StandingsTeamUpdatedEventHandler> logger)
    : IHandleMessages<TeamUpdatedEvent>
{
    public async Task Handle(TeamUpdatedEvent message)
    {
        //TODO: Update team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToUpdateTeamCommand(message);
        await sender.Send(command);
    }

    private UpdateTeamCommand MapToUpdateTeamCommand(TeamUpdatedEvent message)
    {
        var teamDto = new TeamDto(
            Id: message.Id,
            TeamName: message.TeamName);

        return new UpdateTeamCommand(teamDto);
    }
}

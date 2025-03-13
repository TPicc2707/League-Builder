namespace Standings.Application.Teams.Integrations;

public class TeamCreationEventHandler
    (ISender sender, ILogger<TeamCreationEventHandler> logger)
    : IConsumer<TeamCreationEvent>
{
    public async Task Consume(ConsumeContext<TeamCreationEvent> context)
    {
        //TODO: Create new team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MaptoCreateTeamCommand(context.Message);
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
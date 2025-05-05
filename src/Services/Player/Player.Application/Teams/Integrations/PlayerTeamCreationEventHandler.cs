namespace Player.Application.Teams.Integrations;

public class PlayerTeamCreationEventHandler
    (ISender sender, ILogger<PlayerTeamCreationEventHandler> logger)
    : IConsumer<TeamCreationEvent>
{
    public async Task Consume(ConsumeContext<TeamCreationEvent> context)
    {
        //TODO: Create new team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateTeamCommand(context.Message);
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

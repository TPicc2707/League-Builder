namespace Player.Application.Teams.Integrations;

public class PlayerTeamUpdatedEventHandler(ISender sender, ILogger<PlayerTeamUpdatedEventHandler> logger)
    : IConsumer<TeamUpdatedEvent>
{
    public async Task Consume(ConsumeContext<TeamUpdatedEvent> context)
    {
        //TODO: Update league
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToUpdateTeamCommand(context.Message);
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

namespace Player.Application.Teams.Integrations;

public class TeamUpdatedEventHandler(ISender sender, ILogger<TeamUpdatedEventHandler> logger)
    : IConsumer<TeamUpatedEvent>
{
    public async Task Consume(ConsumeContext<TeamUpatedEvent> context)
    {
        //TODO: Update league
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToUpdateTeamCommand(context.Message);
        await sender.Send(command);
    }

    private UpdateTeamCommand MapToUpdateTeamCommand(TeamUpatedEvent message)
    {
        var teamDto = new TeamDto(
            Id: message.Id,
            TeamName: message.TeamName,
            Description: message.Description);

        return new UpdateTeamCommand(teamDto);
    }
}

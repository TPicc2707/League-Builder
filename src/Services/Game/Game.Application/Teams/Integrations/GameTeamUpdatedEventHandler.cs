namespace Game.Application.Teams.Integrations;

public class GameTeamUpdatedEventHandler(ISender sender, ILogger<GameTeamUpdatedEventHandler> logger)
    : IConsumer<TeamUpdatedEvent>
{
    public async Task Consume(ConsumeContext<TeamUpdatedEvent> context)
    {
        //TODO: Update team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToUpdateTeamCommand(context.Message);
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

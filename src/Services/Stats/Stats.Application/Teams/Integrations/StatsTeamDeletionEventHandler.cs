namespace Stats.Application.Teams.Integrations;

public class StatsTeamDeletionEventHandler
    (ISender sender, ILogger<StatsTeamDeletionEventHandler> logger)
    : IConsumer<TeamDeletionEvent>
{
    public async Task Consume(ConsumeContext<TeamDeletionEvent> context)
    {
        //TODO: Delete Team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToDeleteTeamCommand(context.Message);
        await sender.Send(command);
    }

    private DeleteTeamCommand MapToDeleteTeamCommand(TeamDeletionEvent message)
    {
        return new DeleteTeamCommand(message.Id);
    }
}

namespace Stats.Application.Players.Integrations;

public class StatsPlayerDeletionEventHandler
    (ISender sender, ILogger<StatsPlayerDeletionEventHandler> logger)
    : IHandleMessages<PlayerDeletionEvent>
{
    public async Task Handle(PlayerDeletionEvent message)
    {
        //TODO: Delete Player
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToDeletePlayerCommand(message);
        await sender.Send(command);
    }

    private DeletePlayerCommand MapToDeletePlayerCommand(PlayerDeletionEvent message)
    {
        return new DeletePlayerCommand(message.Id);
    }
}

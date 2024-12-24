namespace Stats.Application.Players.Integrations;

public class PlayerDeletionEventHandler
    (ISender sender, ILogger<PlayerDeletionEventHandler> logger)
    : IConsumer<PlayerDeletionEvent>
{
    public async Task Consume(ConsumeContext<PlayerDeletionEvent> context)
    {
        //TODO: Delete Player
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToDeletePlayerCommand(context.Message);
        await sender.Send(command);
    }

    private DeletePlayerCommand MapToDeletePlayerCommand(PlayerDeletionEvent message)
    {
        return new DeletePlayerCommand(message.Id);
    }
}

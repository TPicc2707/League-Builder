namespace Stats.Application.Games.Integrations;

public class StatsGameDeletionEventHandler
    (ISender sender, ILogger<StatsGameDeletionEventHandler> logger)
    : IConsumer<GameDeletionEvent>
{
    public async Task Consume(ConsumeContext<GameDeletionEvent> context)
    {
        //TODO: Delete Game
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToDeleteGameCommand(context.Message);
        await sender.Send(command);
    }

    private DeleteGameCommand MapToDeleteGameCommand(GameDeletionEvent message)
    {
        return new DeleteGameCommand(message.Id);
    }
}

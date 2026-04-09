namespace Stats.Application.Games.Integrations;

public class StatsGameDeletionEventHandler
    (ISender sender, ILogger<StatsGameDeletionEventHandler> logger)
    : IHandleMessages<GameDeletionEvent>
{
    public async Task Handle(GameDeletionEvent message)
    {
        //TODO: Delete Game
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToDeleteGameCommand(message);
        await sender.Send(command);
    }

    private DeleteGameCommand MapToDeleteGameCommand(GameDeletionEvent message)
    {
        return new DeleteGameCommand(message.Id);
    }
}

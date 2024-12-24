namespace Stats.Application.Games.Integrations;

public class GameUpdatedEventHandler(ISender sender, ILogger<GameUpdatedEventHandler> logger)
    : IConsumer<GameUpdatedEvent>
{
    public async Task Consume(ConsumeContext<GameUpdatedEvent> context)
    {
        //TODO: Update game
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToUpdateGameCommand(context.Message);
        await sender.Send(command);
    }

    private UpdateGameCommand MapToUpdateGameCommand(GameUpdatedEvent message)
    {
        var gameDto = new GameDto(
            Id: message.Id);

        return new UpdateGameCommand(gameDto);
    }
}
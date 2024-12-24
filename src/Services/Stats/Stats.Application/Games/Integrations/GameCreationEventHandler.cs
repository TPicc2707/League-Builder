namespace Stats.Application.Games.Integrations;

public class GameCreationEventHandler
    (ISender sender, ILogger<GameCreationEventHandler> logger)
    : IConsumer<GameCreationEvent>
{
    public async Task Consume(ConsumeContext<GameCreationEvent> context)
    {
        //TODO: Create new game
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MaptoCreateGameCommand(context.Message);
        await sender.Send(command);
    }

    private CreateGameCommand MaptoCreateGameCommand(GameCreationEvent message)
    {
        var gameDto = new GameDto(
            Id: message.Id);

        return new CreateGameCommand(gameDto);
    }
}

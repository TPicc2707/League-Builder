namespace Stats.Application.Games.Integrations;

public class StatsGameCreationEventHandler
    (ISender sender, ILogger<StatsGameCreationEventHandler> logger)
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

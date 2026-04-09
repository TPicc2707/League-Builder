namespace Stats.Application.Games.Integrations;

public class StatsGameCreationEventHandler
    (ISender sender, ILogger<StatsGameCreationEventHandler> logger)
    : IHandleMessages<GameCreationEvent>
{
    public async Task Handle(GameCreationEvent message)
    {
        //TODO: Create new game
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MaptoCreateGameCommand(message);
        await sender.Send(command);
    }

    private CreateGameCommand MaptoCreateGameCommand(GameCreationEvent message)
    {
        var gameDto = new GameDto(
            Id: message.Id);

        return new CreateGameCommand(gameDto);
    }
}

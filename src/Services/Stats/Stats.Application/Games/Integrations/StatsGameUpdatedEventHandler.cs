namespace Stats.Application.Games.Integrations;

public class StatsGameUpdatedEventHandler(ISender sender, ILogger<StatsGameUpdatedEventHandler> logger)
    : IHandleMessages<GameUpdatedEvent>
{
    public async Task Handle(GameUpdatedEvent message)
    {
        //TODO: Update game
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToUpdateGameCommand(message);
        await sender.Send(command);
    }

    private UpdateGameCommand MapToUpdateGameCommand(GameUpdatedEvent message)
    {
        var gameDto = new GameDto(
            Id: message.Id);

        return new UpdateGameCommand(gameDto);
    }
}
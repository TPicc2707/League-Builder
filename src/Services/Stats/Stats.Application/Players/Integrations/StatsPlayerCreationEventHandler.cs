namespace Stats.Application.Players.Integrations;

public class StatsPlayerCreationEventHandler
    (ISender sender, ILogger<StatsPlayerCreationEventHandler> logger)
    : IHandleMessages<PlayerCreationEvent>
{
    public async Task Handle(PlayerCreationEvent message)
    {
        //TODO: Create new player
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MaptoCreatePlayerCommand(message);
        await sender.Send(command);
    }

    private CreatePlayerCommand MaptoCreatePlayerCommand(PlayerCreationEvent message)
    {
        var playerDto = new PlayerDto(
            Id: message.Id,
            FirstName: message.FirstName,
            LastName: message.LastName);

        return new CreatePlayerCommand(playerDto);
    }
}

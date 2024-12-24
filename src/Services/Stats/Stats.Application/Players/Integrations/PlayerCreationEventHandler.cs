namespace Stats.Application.Players.Integrations;

public class PlayerCreationEventHandler
    (ISender sender, ILogger<PlayerCreationEventHandler> logger)
    : IConsumer<PlayerCreationEvent>
{
    public async Task Consume(ConsumeContext<PlayerCreationEvent> context)
    {
        //TODO: Create new player
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MaptoCreatePlayerCommand(context.Message);
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

namespace Stats.Application.Players.Integrations;

public class StatsPlayerUpdatedEventHandler(ISender sender, ILogger<StatsPlayerUpdatedEventHandler> logger)
    : IConsumer<PlayerUpdatedEvent>
{
    public async Task Consume(ConsumeContext<PlayerUpdatedEvent> context)
    {
        //TODO: Update player
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToUpdatePlayerCommand(context.Message);
        await sender.Send(command);
    }

    private UpdatePlayerCommand MapToUpdatePlayerCommand(PlayerUpdatedEvent message)
    {
        var playerDto = new PlayerDto(
            Id: message.Id,
            FirstName: message.FirstName,
            LastName: message.LastName);

        return new UpdatePlayerCommand(playerDto);
    }
}

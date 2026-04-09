namespace Stats.Application.Players.Integrations;

public class StatsPlayerUpdatedEventHandler(ISender sender, ILogger<StatsPlayerUpdatedEventHandler> logger)
    : IHandleMessages<PlayerUpdatedEvent>
{
    public async Task Handle(PlayerUpdatedEvent message)
    {
        //TODO: Update player
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToUpdatePlayerCommand(message);
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

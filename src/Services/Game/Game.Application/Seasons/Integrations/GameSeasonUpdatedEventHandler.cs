namespace Game.Application.Seasons.Integrations;

public class GameSeasonUpdatedEventHandler(ISender sender, ILogger<GameSeasonUpdatedEventHandler> logger)
    : IConsumer<SeasonUpdatedEvent>
{
    public async Task Consume(ConsumeContext<SeasonUpdatedEvent> context)
    {
        //TODO: Update season
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToUpdateSeasonCommand(context.Message);
        await sender.Send(command);
    }

    private UpdateSeasonCommand MapToUpdateSeasonCommand(SeasonUpdatedEvent message)
    {
        var seasonDto = new SeasonDto(
            Id: message.Id,
            Year: message.Year);

        return new UpdateSeasonCommand(seasonDto);
    }
}

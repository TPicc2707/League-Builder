namespace Stats.Application.Seasons.Integrations;

public class StatsSeasonCreationEventHandler
    (ISender sender, ILogger<StatsSeasonCreationEventHandler> logger)
    : IHandleMessages<SeasonCreationEvent>
{
    public async Task Handle(SeasonCreationEvent message)
    {
        //TODO: Create new season
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MaptoCreateSeasonCommand(message);
        await sender.Send(command);
    }

    private CreateSeasonCommand MaptoCreateSeasonCommand(SeasonCreationEvent message)
    {
        var seasonDto = new SeasonDto(
            Id: message.Id,
            Year: message.Year);

        return new CreateSeasonCommand(seasonDto);
    }
}

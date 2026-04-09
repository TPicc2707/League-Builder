namespace Standings.Application.Seasons.Integrations;

public class StandingsSeasonUpdatedEventHandler(ISender sender, ILogger<StandingsSeasonUpdatedEventHandler> logger)
    : IHandleMessages<SeasonUpdatedEvent>
{
    public async Task Handle(SeasonUpdatedEvent message)
    {
        //TODO: Update season
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToUpdateSeasonCommand(message);
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

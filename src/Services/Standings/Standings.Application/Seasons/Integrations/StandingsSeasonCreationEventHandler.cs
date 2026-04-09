namespace Standings.Application.Seasons.Integrations;

public class StandingsSeasonCreationEventHandler
    (ISender sender, ILogger<StandingsSeasonCreationEventHandler> logger)
    : IHandleMessages<SeasonCreationEvent>
{
    public async Task Handle(SeasonCreationEvent context)
    {
        //TODO: Create new season
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.GetType().Name);

        var command = MaptoCreateSeasonCommand(context);
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

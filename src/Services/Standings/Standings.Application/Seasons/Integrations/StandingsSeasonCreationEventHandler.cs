namespace Standings.Application.Seasons.Integrations;

public class StandingsSeasonCreationEventHandler
    (ISender sender, ILogger<StandingsSeasonCreationEventHandler> logger)
    : IConsumer<SeasonCreationEvent>
{
    public async Task Consume(ConsumeContext<SeasonCreationEvent> context)
    {
        //TODO: Create new season
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MaptoCreateSeasonCommand(context.Message);
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

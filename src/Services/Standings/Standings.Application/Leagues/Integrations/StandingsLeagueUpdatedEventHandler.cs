namespace Game.Application.Leagues.Integrations;

public class StandingsLeagueUpdatedEventHandler(ISender sender, ILogger<StandingsLeagueUpdatedEventHandler> logger)
    : IConsumer<LeagueUpdatedEvent>
{
    public async Task Consume(ConsumeContext<LeagueUpdatedEvent> context)
    {
        //TODO: Update league
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToUpdateLeagueCommand(context.Message);
        await sender.Send(command);
    }

    private UpdateLeagueCommand MapToUpdateLeagueCommand(LeagueUpdatedEvent message)
    {
        var leagueDto = new LeagueDto(
            Id: message.Id,
            Name: message.Name);

        return new UpdateLeagueCommand(leagueDto);
    }
}

namespace Game.Application.Leagues.Integrations;

public class StandingsLeagueUpdatedEventHandler(ISender sender, ILogger<StandingsLeagueUpdatedEventHandler> logger)
    : IHandleMessages<LeagueUpdatedEvent>
{
    public async Task Handle(LeagueUpdatedEvent message)
    {
        //TODO: Update league
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToUpdateLeagueCommand(message);
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

namespace Game.Application.Leagues.Integrations;

public class GameLeagueCreationEventHandler
    (ISender sender, ILogger<GameLeagueCreationEventHandler> logger)
    : IHandleMessages<LeagueCreationEvent>
{
    public async Task Handle(LeagueCreationEvent message)
    {
        //TODO: Create new team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MaptoCreateLeagueCommand(message);
        await sender.Send(command);
    }

    private CreateLeagueCommand MaptoCreateLeagueCommand(LeagueCreationEvent message)
    {
        var leagueDto = new LeagueDto(
            Id: message.Id,
            Name: message.Name);

        return new CreateLeagueCommand(leagueDto);
    }
}

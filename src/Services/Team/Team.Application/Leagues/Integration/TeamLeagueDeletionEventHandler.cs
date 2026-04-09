namespace Team.Application.Leagues.Integration;
public class TeamLeagueDeletionEventHandler
    (ISender sender, ILogger<TeamLeagueDeletionEventHandler> logger)
    : IHandleMessages<LeagueDeletionEvent>
{
    public async Task Handle(LeagueDeletionEvent message)
    {
        //TODO: Delete league
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToDeleteLeagueCommand(message);
        await sender.Send(command);
    }

    private DeleteLeagueCommand MapToDeleteLeagueCommand(LeagueDeletionEvent message)
    {
        return new DeleteLeagueCommand(message.Id);
    }
}

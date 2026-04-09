namespace Game.Application.Leagues.Integrations;

public class GameLeagueDeletionEventHandler
    (ISender sender, ILogger<GameLeagueDeletionEventHandler> logger)
    : IHandleMessages<LeagueDeletionEvent>
{
    public async Task Handle(LeagueDeletionEvent message)
    {
        //TODO: Delete Team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToDeleteLeagueCommand(message);
        await sender.Send(command);
    }

    private DeleteLeagueCommand MapToDeleteLeagueCommand(LeagueDeletionEvent message)
    {
        return new DeleteLeagueCommand(message.Id);
    }
}
namespace Standings.Application.Leagues.Integrations;

public class StandingsLeagueDeletionEventHandler
    (ISender sender, ILogger<StandingsLeagueDeletionEventHandler> logger)
    : IHandleMessages<LeagueDeletionEvent>
{
    public async Task Handle(LeagueDeletionEvent context)
    {
        //TODO: Delete Team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.GetType().Name);

        var command = MapToDeleteLeagueCommand(context);
        await sender.Send(command);
    }

    private DeleteLeagueCommand MapToDeleteLeagueCommand(LeagueDeletionEvent message)
    {
        return new DeleteLeagueCommand(message.Id);
    }
}
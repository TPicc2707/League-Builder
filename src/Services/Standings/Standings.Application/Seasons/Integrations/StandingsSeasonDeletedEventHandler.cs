namespace Standings.Application.Seasons.Integrations;

public class SeasonDeletionEventHandler
    (ISender sender, ILogger<SeasonDeletionEventHandler> logger)
    : IHandleMessages<SeasonDeletionEvent>
{
    public async Task Handle(SeasonDeletionEvent message)
    {
        //TODO: Delete Season
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToDeleteSeasonCommand(message);
        await sender.Send(command);
    }

    private DeleteSeasonCommand MapToDeleteSeasonCommand(SeasonDeletionEvent message)
    {
        return new DeleteSeasonCommand(message.Id);
    }
}

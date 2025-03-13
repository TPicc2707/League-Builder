namespace Standings.Application.Seasons.Integrations;

public class SeasonDeletionEventHandler
    (ISender sender, ILogger<SeasonDeletionEventHandler> logger)
    : IConsumer<SeasonDeletionEvent>
{
    public async Task Consume(ConsumeContext<SeasonDeletionEvent> context)
    {
        //TODO: Delete Season
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToDeleteSeasonCommand(context.Message);
        await sender.Send(command);
    }

    private DeleteSeasonCommand MapToDeleteSeasonCommand(SeasonDeletionEvent message)
    {
        return new DeleteSeasonCommand(message.Id);
    }
}

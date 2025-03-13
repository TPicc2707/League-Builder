namespace Standings.Application.Leagues.Integrations;

public class LeagueDeletionEventHandler
    (ISender sender, ILogger<LeagueDeletionEventHandler> logger)
    : IConsumer<LeagueDeletionEvent>
{
    public async Task Consume(ConsumeContext<LeagueDeletionEvent> context)
    {
        //TODO: Delete Team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToDeleteLeagueCommand(context.Message);
        await sender.Send(command);
    }

    private DeleteLeagueCommand MapToDeleteLeagueCommand(LeagueDeletionEvent message)
    {
        return new DeleteLeagueCommand(message.Id);
    }
}
namespace Team.Application.Leagues.Integration;
public class TeamLeagueDeletionEventHandler
    (ISender sender, ILogger<TeamLeagueDeletionEventHandler> logger)
    : IConsumer<LeagueDeletionEvent>
{
    public async Task Consume(ConsumeContext<LeagueDeletionEvent> context)
    {
        //TODO: Delete league
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToDeleteLeagueCommand(context.Message);
        await sender.Send(command);
    }

    private DeleteLeagueCommand MapToDeleteLeagueCommand(LeagueDeletionEvent message)
    {
        return new DeleteLeagueCommand(message.Id);
    }
}

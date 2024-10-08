namespace Team.Application.Leagues.Integration;
public class LeagueDeletedEventHandler
    (ISender sender, ILogger<LeagueDeletedEventHandler> logger)
    : IConsumer<LeagueDeletedEvent>
{
    public async Task Consume(ConsumeContext<LeagueDeletedEvent> context)
    {
        //TODO: Update league
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToDeleteLeagueCommand(context.Message);
        await sender.Send(command);
    }

    private DeleteLeagueCommand MapToDeleteLeagueCommand(LeagueDeletedEvent message)
    {
        return new DeleteLeagueCommand(message.Id);
    }
}

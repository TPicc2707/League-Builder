namespace Game.Application.Leagues.Integrations;

public class GameLeagueCreationEventHandler
    (ISender sender, ILogger<GameLeagueCreationEventHandler> logger)
    : IConsumer<LeagueCreationEvent>
{
    public async Task Consume(ConsumeContext<LeagueCreationEvent> context)
    {
        //TODO: Create new team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MaptoCreateLeagueCommand(context.Message);
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

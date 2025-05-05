namespace Team.Application.Leagues.Integration;
public class LeagueCreationEventHandler
    (ISender sender, ILogger<LeagueCreationEventHandler> logger)
    : IConsumer<LeagueCreationEvent>
{
    public async Task Consume(ConsumeContext<LeagueCreationEvent> context)
    {
        //TODO: Create new league
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateLeagueCommand(context.Message);
        await sender.Send(command);
    }

    private CreateLeagueCommand MapToCreateLeagueCommand(LeagueCreationEvent message)
    {
        var leagueDto = new LeagueDto(
            Id: message.Id,
            Name: message.Name,
            Sport: message.Sport,
            Description: message.Description);

        return new CreateLeagueCommand(leagueDto);
    }
}

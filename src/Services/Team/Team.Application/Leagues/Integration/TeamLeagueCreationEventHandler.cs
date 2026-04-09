namespace Team.Application.Leagues.Integration;
public class LeagueCreationEventHandler
    (ISender sender, ILogger<LeagueCreationEventHandler> logger)
    : IHandleMessages<LeagueCreationEvent>
{
    public async Task Handle(LeagueCreationEvent message)
    {
        //TODO: Create new league
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToCreateLeagueCommand(message);
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

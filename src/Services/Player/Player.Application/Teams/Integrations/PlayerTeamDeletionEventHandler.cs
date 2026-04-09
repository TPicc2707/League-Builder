namespace Player.Application.Teams.Integrations;

public class PlayerTeamDeletionEventHandler
    (ISender sender, ILogger<PlayerTeamDeletionEventHandler> logger)
    : IHandleMessages<TeamDeletionEvent>
{
    public async Task Handle(TeamDeletionEvent message)
    {
        //TODO: Delete Team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", message.GetType().Name);

        var command = MapToDeleteTeamCommand(message);
        await sender.Send(command);
    }

    private DeleteTeamCommand MapToDeleteTeamCommand(TeamDeletionEvent message)
    {
        return new DeleteTeamCommand(message.Id);
    }
}

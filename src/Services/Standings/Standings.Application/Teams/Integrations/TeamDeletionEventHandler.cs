namespace Standings.Application.Teams.Integrations;

public class TeamDeletionEventHandler
    (ISender sender, ILogger<TeamDeletionEventHandler> logger)
    : IConsumer<TeamDeletionEvent>
{
    public async Task Consume(ConsumeContext<TeamDeletionEvent> context)
    {
        //TODO: Delete Team
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToDeleteTeamCommand(context.Message);
        await sender.Send(command);
    }

    private DeleteTeamCommand MapToDeleteTeamCommand(TeamDeletionEvent message)
    {
        return new DeleteTeamCommand(message.Id);
    }
}

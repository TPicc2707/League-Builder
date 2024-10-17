namespace Team.Application.Teams.Commands.DeleteTeam;
public class DeleteTeamHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint)
    : ICommandHandler<DeleteTeamCommand, DeleteTeamResult>
{
    public async Task<DeleteTeamResult> Handle(DeleteTeamCommand command, CancellationToken cancellationToken)
    {
        //Delete Team enity from command object
        //save to database
        //return result

        var teamId = TeamId.Of(command.TeamId);
        var team = await dbContext.Teams
            .FindAsync([teamId], cancellationToken: cancellationToken);

        if (team == null)
        {
            throw new TeamNotFoundException(command.TeamId);
        }

        dbContext.Teams.Remove(team);
        await dbContext.SaveChangesAsync(cancellationToken);

        var eventMessage = new TeamDeletionEvent()
        {
            Id = command.TeamId
        };

        await publishEndpoint.Publish(eventMessage, cancellationToken);


        return new DeleteTeamResult(true);
    }
}

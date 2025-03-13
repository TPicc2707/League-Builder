namespace Standings.Application.Teams.Commands.DeleteTeam;

public class DeleteTeamHandler(IApplicationDbContext dbContext)
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

        return new DeleteTeamResult(true);
    }
}

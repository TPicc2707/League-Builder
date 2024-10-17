namespace Player.Application.Teams.Commands.UpdateTeam;

public class UpdateTeamHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateTeamCommand, UpdateTeamResult>
{
    public async Task<UpdateTeamResult> Handle(UpdateTeamCommand command, CancellationToken cancellationToken)
    {
        //Update Team entity from command object
        //save to database
        //return result

        var teamId = TeamId.Of(command.Team.Id);
        var team = await dbContext.Teams.FindAsync([teamId], cancellationToken: cancellationToken);
        if (team is null)
            throw new TeamNotFoundException(command.Team.Id);

        UpdateTeamWithNewValues(team, command.Team);

        dbContext.Teams.Update(team);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateTeamResult(true);
    }

    private void UpdateTeamWithNewValues(Team team, TeamDto teamDto)
    {
        team.Update(
            teamName: teamDto.TeamName,
            description: teamDto.Description);
    }
}

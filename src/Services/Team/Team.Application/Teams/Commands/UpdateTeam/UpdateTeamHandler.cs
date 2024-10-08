namespace Team.Application.Teams.Commands.UpdateTeam;
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

        await UpdateTeamWithNewValues(team, command.Team);

        dbContext.Teams.Update(team);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateTeamResult(true);
    }

    private async Task UpdateTeamWithNewValues(Domain.Models.Team team, TeamDto teamDto)
    {
        var updatedTeamAddress = Address.Of(teamDto.TeamAddress.FirstName, teamDto.TeamAddress.LastName, teamDto.TeamAddress.EmailAddress, teamDto.TeamAddress.AddressLine, teamDto.TeamAddress.Country, teamDto.TeamAddress.State, teamDto.TeamAddress.ZipCode);

        team.Update(
            leagueId: LeagueId.Of(teamDto.LeagueId),
            teamName: TeamName.Of(teamDto.TeamName),
            teamAddress: updatedTeamAddress,
            description: teamDto.Description,
            imageFile: teamDto.ImageFile,
            status: teamDto.TeamStatus);
    }
}

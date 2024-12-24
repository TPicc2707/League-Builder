namespace Stats.Application.Teams.Commands.CreateTeam;

public class CreateTeamHandler(IApplicationDbContext dbContext)
     : ICommandHandler<CreateTeamCommand, CreateTeamResult>
{
    public async Task<CreateTeamResult> Handle(CreateTeamCommand command, CancellationToken cancellationToken)
    {
        var team = CreateNewTeam(command.Team);

        dbContext.Teams.Add(team);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateTeamResult(team.Id.Value);
    }

    private Team CreateNewTeam(TeamDto teamDto)
    {

        var newTeam = Team.Create(
                id: TeamId.Of(teamDto.Id),
                teamName: teamDto.TeamName
                );

        return newTeam;
    }
}

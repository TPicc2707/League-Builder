namespace Team.Application.Teams.Commands.CreateTeam;
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

    private Domain.Models.Team CreateNewTeam(TeamDto teamDto)
    {
        var teamAddress = Address.Of(teamDto.TeamAddress.FirstName, teamDto.TeamAddress.LastName, teamDto.TeamAddress.EmailAddress, teamDto.TeamAddress.AddressLine, teamDto.TeamAddress.Country, teamDto.TeamAddress.State, teamDto.TeamAddress.ZipCode);

        var newTeam = Domain.Models.Team.Create(
                id: TeamId.Of(Guid.NewGuid()),
                leagueId: LeagueId.Of(teamDto.LeagueId),
                teamName: TeamName.Of(teamDto.TeamName),
                teamAddress: teamAddress,
                description: teamDto.Description,
                imageFile: teamDto.ImageFile
                );

        return newTeam;
    }
}

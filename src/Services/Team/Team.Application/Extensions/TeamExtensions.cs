namespace Team.Application.Extensions;
public static class TeamExtensions
{
    public static IEnumerable<TeamDto> ToTeamDtoList(this IEnumerable<Domain.Models.Team> teams)
    {
        return teams.Select(team => new TeamDto(
            Id: team.Id.Value,
            LeagueId: team.LeagueId.Value,
            TeamName: team.TeamName.Value,
            TeamAddress: new AddressDto(
                team.TeamAddress.FirstName,
                team.TeamAddress.LastName,
                team.TeamAddress.EmailAddress,
                team.TeamAddress.AddressLine,
                team.TeamAddress.City,
                team.TeamAddress.Country,
                team.TeamAddress.State,
                team.TeamAddress.ZipCode),
            Description: team.Description,
            ImageFile: team.ImageFile,
            TeamStatus: team.TeamStatus
            ));
    }

    public static TeamDto ToSingleTeamDto(this Domain.Models.Team team)
    {
        return new TeamDto(
            Id: team.Id.Value,
            LeagueId: team.LeagueId.Value,
            TeamName: team.TeamName.Value,
            TeamAddress: new AddressDto(
                team.TeamAddress.FirstName,
                team.TeamAddress.LastName,
                team.TeamAddress.EmailAddress,
                team.TeamAddress.AddressLine,
                team.TeamAddress.City,
                team.TeamAddress.Country,
                team.TeamAddress.State,
                team.TeamAddress.ZipCode),
            Description: team.Description,
            ImageFile: team.ImageFile,
            TeamStatus: team.TeamStatus
            );
    }
}

namespace Standings.Application.Extensions;

public static class StandingsExtensions
{
    public static IEnumerable<StandingsDto> ToStandingsDtoList(this IEnumerable<Domain.Models.Standings> standings, List<Team> teams)
    {
        return standings.Select(standings => new StandingsDto(
            Id: standings.Id.Value,
            LeagueId: standings.LeagueId.Value,
            SeasonId: standings.SeasonId.Value,
            StandingsDetail: new StandingsDetailDto(
                standings.StandingsDetail.GamesPlayed,
                standings.StandingsDetail.Wins,
                standings.StandingsDetail.Losses,
                standings.StandingsDetail.Ties),
            StandingsStatus: standings.StandingsStatus,
            Team: new TeamDto(
                standings.TeamId.Value,
                teams.FirstOrDefault(x => x.Id == standings.TeamId).TeamName
            )));
    }

    public static StandingsDto ToSingleStandingsDto(this Domain.Models.Standings standings, Team team)
    {
        return new StandingsDto(
            Id: standings.Id.Value,
            LeagueId: standings.LeagueId.Value,
            SeasonId: standings.SeasonId.Value,
            StandingsDetail: new StandingsDetailDto(
                standings.StandingsDetail.GamesPlayed,
                standings.StandingsDetail.Wins,
                standings.StandingsDetail.Losses,
                standings.StandingsDetail.Ties),
            StandingsStatus: standings.StandingsStatus,
            Team: new TeamDto(
                team.Id.Value,
                team.TeamName));
    }
}

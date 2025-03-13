namespace Standings.Application.Extensions;

public static class StandingsExtensions
{
    public static IEnumerable<StandingsDto> ToStandingsDtoList(this IEnumerable<Domain.Models.Standings> standings)
    {
        return standings.Select(standings => new StandingsDto(
            Id: standings.Id.Value,
            LeagueId: standings.LeagueId.Value,
            TeamId: standings.TeamId.Value,
            SeasonId: standings.SeasonId.Value,
            StandingsDetail: new StandingsDetailDto(
                standings.StandingsDetail.GamesPlayed,
                standings.StandingsDetail.Wins,
                standings.StandingsDetail.Losses,
                standings.StandingsDetail.Ties),
            StandingsStatus: standings.StandingsStatus));
    }

    public static StandingsDto ToSingleStandingsDto(this Domain.Models.Standings standings)
    {
        return new StandingsDto(
            Id: standings.Id.Value,
            LeagueId: standings.LeagueId.Value,
            TeamId: standings.TeamId.Value,
            SeasonId: standings.SeasonId.Value,
            StandingsDetail: new StandingsDetailDto(
                standings.StandingsDetail.GamesPlayed,
                standings.StandingsDetail.Wins,
                standings.StandingsDetail.Losses,
                standings.StandingsDetail.Ties),
            StandingsStatus: standings.StandingsStatus);
    }
}

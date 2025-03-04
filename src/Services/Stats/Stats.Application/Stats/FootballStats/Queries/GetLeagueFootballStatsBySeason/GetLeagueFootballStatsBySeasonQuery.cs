namespace Stats.Application.Stats.FootballStats.Queries.GetLeagueFootballStatsBySeason;

public record GetLeagueFootballStatsBySeasonQuery(Guid LeagueId, Guid SeasonId)
    : IQuery<GetLeagueFootballStatsBySeasonResult>;

public record GetLeagueFootballStatsBySeasonResult(IEnumerable<FootballStatsDto> FootballStat);
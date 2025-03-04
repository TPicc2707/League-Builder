namespace Stats.Application.Stats.FootballStats.Queries.GetFootballStatsByLeague;

public record GetFootballStatsByLeagueQuery(Guid LeagueId)
    : IQuery<GetFootballStatsByLeagueResult>;

public record GetFootballStatsByLeagueResult(IEnumerable<FootballStatsDto> FootballStats);

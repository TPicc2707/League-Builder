namespace Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatsByLeague;

public record GetBaseballStatsByLeagueQuery(Guid LeagueId)
    : IQuery<GetBaseballStatsByLeagueResult>;

public record GetBaseballStatsByLeagueResult(IEnumerable<BaseballStatsDto> BaseballStats);
namespace Stats.Application.Stats.BaseballStats.Queries.GetLeagueBaseballStatsBySeason;

public record GetLeagueBaseballStatsBySeasonQuery(Guid LeagueId, Guid SeasonId)
    : IQuery<GetLeagueBaseballStatsBySeasonResult>;

public record GetLeagueBaseballStatsBySeasonResult(IEnumerable<BaseballStatsDto> BaseballStats);

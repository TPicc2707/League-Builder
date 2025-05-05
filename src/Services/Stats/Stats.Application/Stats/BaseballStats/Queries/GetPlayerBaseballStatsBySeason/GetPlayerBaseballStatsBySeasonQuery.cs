namespace Stats.Application.Stats.BaseballStats.Queries.GetPlayerBaseballStatsBySeason;

public record GetPlayerBaseballStatsBySeasonQuery(Guid PlayerId, Guid SeasonId)
    : IQuery<GetPlayerBaseballStatsBySeasonResult>;

public record GetPlayerBaseballStatsBySeasonResult(IEnumerable<BaseballStatsDto> BaseballStats);

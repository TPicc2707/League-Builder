namespace Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatsByPlayer;

public record GetBaseballStatsByPlayerQuery(Guid PlayerId)
    : IQuery<GetBaseballStatsByPlayerResult>;

public record GetBaseballStatsByPlayerResult(IEnumerable<BaseballStatsDto> BaseballStats);
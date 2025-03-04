namespace Stats.Application.Stats.BaseballStats.Queries.GetBaseballStats;

public record GetBaseballStatsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetBaseballStatsResult>;

public record GetBaseballStatsResult(PaginatedResult<BaseballStatsDto> BaseballStats);
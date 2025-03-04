namespace Stats.Application.Stats.FootballStats.Queries.GetFootballStats;

public record GetFootballStatsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetFootballStatsResult>;

public record GetFootballStatsResult(PaginatedResult<FootballStatsDto> FootballStats);

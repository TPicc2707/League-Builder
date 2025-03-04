namespace Stats.Application.Stats.BasketballStats.Queries.GetBasketballStats;

public record GetBasketballStatsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetBasketballStatsResult>;

public record GetBasketballStatsResult(PaginatedResult<BasketballStatsDto> BasketballStats);
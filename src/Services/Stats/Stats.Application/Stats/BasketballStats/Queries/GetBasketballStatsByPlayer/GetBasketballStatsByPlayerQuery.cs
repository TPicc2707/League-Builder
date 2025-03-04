namespace Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatsByPlayer;

public record GetBasketballStatsByPlayerQuery(Guid PlayerId)
    : IQuery<GetBasketballStatsByPlayerResult>;

public record GetBasketballStatsByPlayerResult(IEnumerable<BasketballStatsDto> BasketballStats);
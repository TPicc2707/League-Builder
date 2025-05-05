namespace Stats.Application.Stats.BasketballStats.Queries.GetPlayerBasketballStatsByGame;

public record GetPlayerBasketballStatsByGameQuery(Guid PlayerId, Guid GameId)
    : IQuery<GetPlayerBasketballStatsByGameResult>;

public record GetPlayerBasketballStatsByGameResult(BasketballStatsDto BasketballStats);

namespace Stats.Application.Stats.BasketballStats.Queries.GetTeamBasketballStatsByGame;

public record GetTeamBasketballStatsByGameQuery(Guid TeamId, Guid GameId)
    : IQuery<GetTeamBasketballStatsByGameResult>;

public record GetTeamBasketballStatsByGameResult(IEnumerable<BasketballStatsDto> BasketballStats);


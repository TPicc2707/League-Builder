namespace Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatsByLeague;

public record GetBasketballStatsByLeagueQuery(Guid LeagueId)
    : IQuery<GetBasketballStatsByLeagueResult>;

public record GetBasketballStatsByLeagueResult(IEnumerable<BasketballStatsDto> BasketballStats);
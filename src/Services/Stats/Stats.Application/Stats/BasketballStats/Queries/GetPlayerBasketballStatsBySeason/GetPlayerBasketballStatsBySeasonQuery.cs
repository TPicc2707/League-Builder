namespace Stats.Application.Stats.BasketballStats.Queries.GetPlayerBasketballStatsBySeason;

public record GetPlayerBasketballStatsBySeasonQuery(Guid PlayerId, Guid SeasonId)
    : IQuery<GetPlayerBasketballStatsBySeasonResult>;

public record GetPlayerBasketballStatsBySeasonResult(IEnumerable<BasketballStatsDto> BasketballStat);

namespace Stats.Application.Stats.BasketballStats.Queries.GetLeagueBasketballStatsBySeason;

public record GetLeagueBasketballStatsBySeasonQuery(Guid LeagueId, Guid SeasonId)
    : IQuery<GetLeagueBasketballStatsBySeasonResult>;

public record GetLeagueBasketballStatsBySeasonResult(IEnumerable<BasketballStatsDto> BasketballStats);

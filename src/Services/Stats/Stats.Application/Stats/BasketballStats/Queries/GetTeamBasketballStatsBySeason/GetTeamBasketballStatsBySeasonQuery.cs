namespace Stats.Application.Stats.BasketballStats.Queries.GetTeamBasketballStatsBySeason;

public record GetTeamBasketballStatsBySeasonQuery(Guid TeamId, Guid SeasonId)
    : IQuery<GetTeamBasketballStatsBySeasonResult>;

public record GetTeamBasketballStatsBySeasonResult(IEnumerable<BasketballStatsDto> BasketballStats);

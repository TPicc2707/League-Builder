namespace Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatsByTeam;

public record GetBasketballStatsByTeamQuery(Guid TeamId)
    : IQuery<GetBasketballStatsByTeamResult>;

public record GetBasketballStatsByTeamResult(IEnumerable<BasketballStatsDto> BasketballStats);
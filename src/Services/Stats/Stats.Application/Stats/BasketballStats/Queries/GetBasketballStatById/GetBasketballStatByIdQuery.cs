namespace Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatById;

public record GetBasketballStatByIdQuery(Guid Id) : IQuery<GetBasketballStatByIdResult>;

public record GetBasketballStatByIdResult(BasketballStatsDto BasketballStat);
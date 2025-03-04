namespace Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatById;

public record GetBaseballStatByIdQuery(Guid Id) : IQuery<GetBaseballStatByIdResult>;

public record GetBaseballStatByIdResult(BaseballStatsDto BaseballStat);
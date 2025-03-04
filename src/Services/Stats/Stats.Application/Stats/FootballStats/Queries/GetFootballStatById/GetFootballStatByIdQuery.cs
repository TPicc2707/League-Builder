namespace Stats.Application.Stats.FootballStats.Queries.GetFootballStatsById;

public record GetFootballStatByIdQuery(Guid Id) : IQuery<GetFootballStatByIdResult>;

public record GetFootballStatByIdResult(FootballStatsDto FootballStats);

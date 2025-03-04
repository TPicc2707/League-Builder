namespace Stats.Application.Stats.FootballStats.Queries.GetFootballStatsByPlayer;

public record GetFootballStatsByPlayerQuery(Guid PlayerId)
    : IQuery<GetFootballStatsByPlayerResult>;

public record GetFootballStatsByPlayerResult(IEnumerable<FootballStatsDto> FootballStats);
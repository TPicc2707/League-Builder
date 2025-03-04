namespace Stats.Application.Stats.FootballStats.Queries.GetFootballStatsByTeam;

public record GetFootballStatsByTeamQuery(Guid TeamId)
    : IQuery<GetFootballStatsByTeamResult>;

public record GetFootballStatsByTeamResult(IEnumerable<FootballStatsDto> FootballStats);
namespace Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatsByTeam;

public record GetBaseballStatsByTeamQuery(Guid TeamId)
    : IQuery<GetBaseballStatsByTeamResult>;

public record GetBaseballStatsByTeamResult(IEnumerable<BaseballStatsDto> BaseballStats);
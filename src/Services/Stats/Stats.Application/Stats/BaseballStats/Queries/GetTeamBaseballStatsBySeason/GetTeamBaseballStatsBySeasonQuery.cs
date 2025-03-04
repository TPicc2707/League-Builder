namespace Stats.Application.Stats.BaseballStats.Queries.GetTeamBaseballStatsBySeason;

public record GetTeamBaseballStatsBySeasonQuery(Guid TeamId, Guid SeasonId)
    : IQuery<GetTeamBaseballStatsBySeasonResult>;

public record GetTeamBaseballStatsBySeasonResult(IEnumerable<BaseballStatsDto> BaseballStat);

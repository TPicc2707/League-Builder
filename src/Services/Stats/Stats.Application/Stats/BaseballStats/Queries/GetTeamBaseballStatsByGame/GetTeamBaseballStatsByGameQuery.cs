namespace Stats.Application.Stats.BaseballStats.Queries.GetTeamBaseballStatsByGame;

public record GetTeamBaseballStatsByGameQuery(Guid TeamId, Guid GameId)
    : IQuery<GetTeamBaseballStatsByGameResult>;

public record GetTeamBaseballStatsByGameResult(IEnumerable<BaseballStatsDto> BaseballStat);

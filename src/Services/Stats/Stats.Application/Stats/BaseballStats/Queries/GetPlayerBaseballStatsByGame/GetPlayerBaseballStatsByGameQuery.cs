namespace Stats.Application.Stats.BaseballStats.Queries.GetPlayerBaseballStatsByGame;

public record GetPlayerBaseballStatsByGameQuery(Guid PlayerId, Guid GameId)
    : IQuery<GetPlayerBaseballStatsByGameResult>;

public record GetPlayerBaseballStatsByGameResult(BaseballStatsDto BaseballStat);

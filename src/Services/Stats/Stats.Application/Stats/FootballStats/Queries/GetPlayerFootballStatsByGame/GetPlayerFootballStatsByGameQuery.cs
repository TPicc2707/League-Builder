namespace Stats.Application.Stats.FootballStats.Queries.GetPlayerFootballStatsByGame;

public record GetPlayerFootballStatsByGameQuery(Guid PlayerId, Guid GameId)
    : IQuery<GetPlayerFootballStatsByGameResult>;

public record GetPlayerFootballStatsByGameResult(FootballStatsDto FootballStat);

namespace Stats.Application.Stats.FootballStats.Queries.GetTeamFootballStatsByGame;

public record GetTeamFootballStatsByGameQuery(Guid TeamId, Guid GameId)
    : IQuery<GetTeamFootballStatsByGameResult>;

public record GetTeamFootballStatsByGameResult(IEnumerable<FootballStatsDto> FootballStat);

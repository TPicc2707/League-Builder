namespace Stats.Application.Stats.FootballStats.Queries.GetPlayerFootballStatsBySeason;

public record GetPlayerFootballStatsBySeasonQuery(Guid PlayerId, Guid SeasonId)
    : IQuery<GetPlayerFootballStatsBySeasonResult>;

public record GetPlayerFootballStatsBySeasonResult(IEnumerable<FootballStatsDto> FootballStat);

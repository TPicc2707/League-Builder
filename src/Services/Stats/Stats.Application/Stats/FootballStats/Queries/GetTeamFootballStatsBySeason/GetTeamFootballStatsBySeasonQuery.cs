namespace Stats.Application.Stats.FootballStats.Queries.GetTeamFootballStatsBySeason;

public record GetTeamFootballStatsBySeasonQuery(Guid TeamId, Guid SeasonId)
    : IQuery<GetTeamFootballStatsBySeasonResult>;

public record GetTeamFootballStatsBySeasonResult(IEnumerable<FootballStatsDto> FootballStats);

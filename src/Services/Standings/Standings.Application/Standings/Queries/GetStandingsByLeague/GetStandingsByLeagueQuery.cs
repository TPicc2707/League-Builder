namespace Standings.Application.Standings.Queries.GetStandingsByLeague;

public record GetStandingsByLeagueQuery(Guid LeagueId)
    : IQuery<GetStandingsByLeagueResult>;

public record GetStandingsByLeagueResult(IEnumerable<StandingsDto> Standings);
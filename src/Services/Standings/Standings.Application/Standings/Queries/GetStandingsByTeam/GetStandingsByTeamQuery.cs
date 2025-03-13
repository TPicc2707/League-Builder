namespace Standings.Application.Standings.Queries.GetStandingsByTeam;

public record GetStandingsByTeamQuery(Guid TeamId)
    : IQuery<GetStandingsByTeamResult>;

public record GetStandingsByTeamResult(IEnumerable<StandingsDto> Standings);

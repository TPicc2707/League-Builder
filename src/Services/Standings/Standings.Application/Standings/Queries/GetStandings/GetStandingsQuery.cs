namespace Standings.Application.Standings.Queries.GetStandings;

public record GetStandingsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetStandingsResult>;

public record GetStandingsResult(PaginatedResult<StandingsDto> Standings);

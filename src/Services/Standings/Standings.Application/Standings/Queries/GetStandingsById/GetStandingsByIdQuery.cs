namespace Standings.Application.Standings.Queries.GetStandingsById;

public record GetStandingsByIdQuery(Guid Id) : IQuery<GetStandingsByIdResult>;

public record GetStandingsByIdResult(StandingsDto Standings);
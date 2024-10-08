namespace Team.Application.Teams.Queries.GetTeams;
public record GetTeamsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetTeamsResult>;

public record GetTeamsResult(PaginatedResult<TeamDto> Teams);

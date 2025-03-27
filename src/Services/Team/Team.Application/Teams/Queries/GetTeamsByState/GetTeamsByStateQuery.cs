namespace Team.Application.Teams.Queries.GetTeamsByState;

public record GetTeamsByStateQuery(string State)
    : IQuery<GetTeamsByStateResult>;

public record GetTeamsByStateResult(IEnumerable<TeamDto> Teams);
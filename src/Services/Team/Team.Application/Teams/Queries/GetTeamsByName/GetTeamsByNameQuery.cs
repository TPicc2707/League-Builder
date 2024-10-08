namespace Team.Application.Teams.Queries.GetTeamsByName;
public record GetTeamsByNameQuery(string Name)
    : IQuery<GetTeamsByNameResult>;

public record GetTeamsByNameResult(IEnumerable<TeamDto> Teams);
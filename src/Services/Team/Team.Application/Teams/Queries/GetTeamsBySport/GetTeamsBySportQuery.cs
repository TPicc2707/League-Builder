namespace Team.Application.Teams.Queries.GetTeamsBySport;

public record GetTeamsBySportQuery(string Sport)
    : IQuery<GetTeamsBySportResult>;

public record GetTeamsBySportResult(IEnumerable<TeamDto> Teams);
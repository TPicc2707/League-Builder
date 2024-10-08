namespace Team.Application.Teams.Queries.GetTeamsByLeague;
public record GetTeamsByLeagueQuery(Guid LeagueId)
    : IQuery<GetTeamsByLeagueResult>;

public record GetTeamsByLeagueResult(IEnumerable<TeamDto> Teams);
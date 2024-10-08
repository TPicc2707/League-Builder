namespace Team.Application.Teams.Queries.GetTeamsByLeague;
public class GetTeamsByLeagueHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamsByLeagueQuery, GetTeamsByLeagueResult>
{
    public async Task<GetTeamsByLeagueResult> Handle(GetTeamsByLeagueQuery query, CancellationToken cancellationToken)
    {
        // get teams by league using dbContext
        // return result

        var teams = await dbContext.Teams
        .AsNoTracking()
                .Where(o => o.LeagueId == LeagueId.Of(query.LeagueId))
                .OrderBy(o => o.TeamName.Value)
                .ToListAsync(cancellationToken);

        return new GetTeamsByLeagueResult(teams.ToTeamDtoList());
    }
}

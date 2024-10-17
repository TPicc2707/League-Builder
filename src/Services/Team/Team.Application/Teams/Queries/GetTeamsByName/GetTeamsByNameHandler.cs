namespace Team.Application.Teams.Queries.GetTeamsByName;
public class GetTeamsByNameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamsByNameQuery, GetTeamsByNameResult>
{
    public async Task<GetTeamsByNameResult> Handle(GetTeamsByNameQuery query, CancellationToken cancellationToken)
    {
        //get teams by name using dbContext
        //return result

        var teams = await dbContext.Teams
                .AsNoTracking()
                .Where(o => o.TeamName.Value.Contains(query.Name))
                .OrderBy(o => o.TeamName.Value)
                .ToListAsync(cancellationToken);

        return new GetTeamsByNameResult(teams.ToTeamDtoList());
    }
}

namespace Team.Application.Teams.Queries.GetTeamsByState;

public class GetTeamsByStateHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamsByStateQuery, GetTeamsByStateResult>
{
    public async Task<GetTeamsByStateResult> Handle(GetTeamsByStateQuery query, CancellationToken cancellationToken)
    {
        //get teams by state using dbContext
        //return result

       var teams = await dbContext.Teams
                         .AsNoTracking()
                         .Where(o => o.TeamAddress.State.ToLower() == query.State.ToLower())
                         .ToListAsync(cancellationToken);

        return new GetTeamsByStateResult(teams.ToTeamDtoList());
    }
}

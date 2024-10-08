namespace Team.Application.Teams.Queries.GetTeams;
public class GetTeamsQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamsQuery, GetTeamsResult>
{
    public async Task<GetTeamsResult> Handle(GetTeamsQuery query, CancellationToken cancellationToken)
    {
        //get teams with pagination
        //return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Teams.LongCountAsync(cancellationToken);

        var teams = await dbContext.Teams
                        .OrderBy(o => o.TeamName.Value)
                        .Skip(pageSize * pageIndex)
                        .Take(pageSize)
                        .ToListAsync();

        return new GetTeamsResult(
            new PaginatedResult<TeamDto>(
                pageIndex, pageSize, totalCount, teams.ToTeamDtoList()));
    }
}

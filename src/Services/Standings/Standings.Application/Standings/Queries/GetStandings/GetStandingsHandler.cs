namespace Standings.Application.Standings.Queries.GetStandings;

public class GetStandingsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetStandingsQuery, GetStandingsResult>
{
    public async Task<GetStandingsResult> Handle(GetStandingsQuery query, CancellationToken cancellationToken)
    {
        //get standings with pagination
        //return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Standings.LongCountAsync(cancellationToken);

        var standings = await dbContext.Standings
                        .Skip(pageSize * pageIndex)
                        .Take(pageSize)
                        .ToListAsync();

        return new GetStandingsResult(
            new PaginatedResult<StandingsDto>(
                pageIndex, pageSize, totalCount, standings.ToStandingsDtoList()));
    }
}

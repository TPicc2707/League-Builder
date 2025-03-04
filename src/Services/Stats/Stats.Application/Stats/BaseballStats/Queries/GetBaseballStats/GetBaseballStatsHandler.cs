namespace Stats.Application.Stats.BaseballStats.Queries.GetBaseballStats;

public class GetBaseballStatsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBaseballStatsQuery, GetBaseballStatsResult>
{
    public async Task<GetBaseballStatsResult> Handle(GetBaseballStatsQuery query, CancellationToken cancellationToken)
    {
        //get baseball stats with pagination
        //return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.BaseballStats.LongCountAsync(cancellationToken);

        var baseballStats = await dbContext.BaseballStats
                        .Skip(pageSize * pageIndex)
                        .Take(pageSize)
                        .ToListAsync();

        return new GetBaseballStatsResult(
            new PaginatedResult<BaseballStatsDto>(
                pageIndex, pageSize, totalCount, baseballStats.ToBaseballStatsDtoList()));
    }
}


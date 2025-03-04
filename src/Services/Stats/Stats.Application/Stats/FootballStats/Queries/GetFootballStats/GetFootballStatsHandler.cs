namespace Stats.Application.Stats.FootballStats.Queries.GetFootballStats;

public class GetFootballStatsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetFootballStatsQuery, GetFootballStatsResult>
{
    public async Task<GetFootballStatsResult> Handle(GetFootballStatsQuery query, CancellationToken cancellationToken)
    {
        //get football stats with pagination
        //return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.FootballStats.LongCountAsync(cancellationToken);

        var footballStats = await dbContext.FootballStats
                        .Skip(pageSize * pageIndex)
                        .Take(pageSize)
                        .ToListAsync();

        return new GetFootballStatsResult(
            new PaginatedResult<FootballStatsDto>(
                pageIndex, pageSize, totalCount, footballStats.ToFootballStatsDtoList()));
    }
}
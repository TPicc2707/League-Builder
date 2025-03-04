namespace Stats.Application.Stats.BasketballStats.Queries.GetBasketballStats;

public class GetBasketballStatsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBasketballStatsQuery, GetBasketballStatsResult>
{
    public async Task<GetBasketballStatsResult> Handle(GetBasketballStatsQuery query, CancellationToken cancellationToken)
    {
        //get basketball stats with pagination
        //return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.BasketballStats.LongCountAsync(cancellationToken);

        var basketballStats = await dbContext.BasketballStats
                        .Skip(pageSize * pageIndex)
                        .Take(pageSize)
                        .ToListAsync();

        return new GetBasketballStatsResult(
            new PaginatedResult<BasketballStatsDto>(
                pageIndex, pageSize, totalCount, basketballStats.ToBasketballStatsDtoList()));
    }
}

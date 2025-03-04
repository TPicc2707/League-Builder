namespace Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatsByPlayer;

public class GetBaseballStatsByPlayerHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBaseballStatsByPlayerQuery, GetBaseballStatsByPlayerResult>
{
    public async Task<GetBaseballStatsByPlayerResult> Handle(GetBaseballStatsByPlayerQuery query, CancellationToken cancellationToken)
    {
        // get baseball stats by player using dbContext
        // return result

        var baseballStats = await dbContext.BaseballStats
        .AsNoTracking()
                .Where(o => o.PlayerId == PlayerId.Of(query.PlayerId))
                .ToListAsync(cancellationToken);

        return new GetBaseballStatsByPlayerResult(baseballStats.ToBaseballStatsDtoList());
    }
}
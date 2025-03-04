namespace Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatsByPlayer;

public class GetBasketballStatsByPlayerHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBasketballStatsByPlayerQuery, GetBasketballStatsByPlayerResult>
{
    public async Task<GetBasketballStatsByPlayerResult> Handle(GetBasketballStatsByPlayerQuery query, CancellationToken cancellationToken)
    {
        // get basketball stats by player using dbContext
        // return result

        var basketballStats = await dbContext.BasketballStats
        .AsNoTracking()
                .Where(o => o.PlayerId == PlayerId.Of(query.PlayerId))
                .ToListAsync(cancellationToken);

        return new GetBasketballStatsByPlayerResult(basketballStats.ToBasketballStatsDtoList());
    }
}
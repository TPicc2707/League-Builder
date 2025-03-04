namespace Stats.Application.Stats.BasketballStats.Queries.GetPlayerBasketballStatsBySeason;

public class GetPlayerBasketballStatsBySeasonHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayerBasketballStatsBySeasonQuery, GetPlayerBasketballStatsBySeasonResult>
{
    public async Task<GetPlayerBasketballStatsBySeasonResult> Handle(GetPlayerBasketballStatsBySeasonQuery query, CancellationToken cancellationToken)
    {
        // get player basketball stats by season using dbContext
        // return result

        var basketballStats = await dbContext.BasketballStats.AsNoTracking()
                .Where(o => o.PlayerId == PlayerId.Of(query.PlayerId) && o.SeasonId == SeasonId.Of(query.SeasonId))
                .ToListAsync(cancellationToken);

        return new GetPlayerBasketballStatsBySeasonResult(basketballStats.ToBasketballStatsDtoList());
    }
}
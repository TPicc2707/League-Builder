namespace Stats.Application.Stats.BasketballStats.Queries.GetLeagueBasketballStatsBySeason;

public class GetLeagueBasketballStatsBySeasonHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetLeagueBasketballStatsBySeasonQuery, GetLeagueBasketballStatsBySeasonResult>
{
    public async Task<GetLeagueBasketballStatsBySeasonResult> Handle(GetLeagueBasketballStatsBySeasonQuery query, CancellationToken cancellationToken)
    {
        // get league basketball stats by season using dbContext
        // return result

        var basketballStats = await dbContext.BasketballStats.AsNoTracking()
                .Where(o => o.LeagueId == LeagueId.Of(query.LeagueId) && o.SeasonId == SeasonId.Of(query.SeasonId))
                .ToListAsync(cancellationToken);

        return new GetLeagueBasketballStatsBySeasonResult(basketballStats.ToBasketballStatsDtoList());
    }
}

namespace Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatsByLeague;

public class GetBasketballStatsByLeagueHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBasketballStatsByLeagueQuery, GetBasketballStatsByLeagueResult>
{
    public async Task<GetBasketballStatsByLeagueResult> Handle(GetBasketballStatsByLeagueQuery query, CancellationToken cancellationToken)
    {
        // get basketball stats by league using dbContext
        // return result

        var basketballStats = await dbContext.BasketballStats
        .AsNoTracking()
                .Where(o => o.LeagueId == LeagueId.Of(query.LeagueId))
                .ToListAsync(cancellationToken);

        return new GetBasketballStatsByLeagueResult(basketballStats.ToBasketballStatsDtoList());
    }
}

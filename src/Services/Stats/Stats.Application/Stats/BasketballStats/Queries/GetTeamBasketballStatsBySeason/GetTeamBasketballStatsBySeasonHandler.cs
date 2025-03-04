namespace Stats.Application.Stats.BasketballStats.Queries.GetTeamBasketballStatsBySeason;

public class GetTeamBasketballStatsBySeasonHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamBasketballStatsBySeasonQuery, GetTeamBasketballStatsBySeasonResult>
{
    public async Task<GetTeamBasketballStatsBySeasonResult> Handle(GetTeamBasketballStatsBySeasonQuery query, CancellationToken cancellationToken)
    {
        // get team basketball stats by season using dbContext
        // return result

        var basketballStats = await dbContext.BasketballStats.AsNoTracking()
                .Where(o => o.TeamId == TeamId.Of(query.TeamId) && o.SeasonId == SeasonId.Of(query.SeasonId))
                .ToListAsync(cancellationToken);

        return new GetTeamBasketballStatsBySeasonResult(basketballStats.ToBasketballStatsDtoList());
    }
}
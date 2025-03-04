namespace Stats.Application.Stats.BasketballStats.Queries.GetTeamBasketballStatsByGame;

public class GetTeamBasketballStatsByGameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamBasketballStatsByGameQuery, GetTeamBasketballStatsByGameResult>
{
    public async Task<GetTeamBasketballStatsByGameResult> Handle(GetTeamBasketballStatsByGameQuery query, CancellationToken cancellationToken)
    {
        // get team basketball stats by game using dbContext
        // return result
        var basketballStats = await dbContext.BasketballStats.AsNoTracking()
                .Where(o => o.TeamId == TeamId.Of(query.TeamId) && o.GameId == GameId.Of(query.GameId))
                .ToListAsync(cancellationToken);

        return new GetTeamBasketballStatsByGameResult(basketballStats.ToBasketballStatsDtoList());
    }
}
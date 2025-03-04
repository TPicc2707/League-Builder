namespace Stats.Application.Stats.BasketballStats.Queries.GetPlayerBasketballStatsByGame;

public class GetPlayerBasketballStatsByGameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayerBasketballStatsByGameQuery, GetPlayerBasketballStatsByGameResult>
{
    public async Task<GetPlayerBasketballStatsByGameResult> Handle(GetPlayerBasketballStatsByGameQuery query, CancellationToken cancellationToken)
    {
        // get player basketball stats by game using dbContext
        // return result

        var playerId = PlayerId.Of(query.PlayerId);
        var gameId = GameId.Of(query.GameId);
        var basketballStat = await dbContext.BasketballStats.FirstOrDefaultAsync(b => b.PlayerId == playerId && b.GameId == gameId, cancellationToken: cancellationToken);
        if (basketballStat is null)
            throw new PlayerBasketballStatsByGameNotFoundException(query.PlayerId);

        return new GetPlayerBasketballStatsByGameResult(basketballStat.ToSingleBasketballStatsDto());
    }
}

namespace Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatById;

public class GetBasketballStatByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBasketballStatByIdQuery, GetBasketballStatByIdResult>
{
    public async Task<GetBasketballStatByIdResult> Handle(GetBasketballStatByIdQuery query, CancellationToken cancellationToken)
    {
        // get basketball stat by id using dbContext
        // return result
        var basketballStatsId = BasketballStatsId.Of(query.Id);
        var basketballStats = await dbContext.BasketballStats.FindAsync([basketballStatsId], cancellationToken: cancellationToken);
        if (basketballStats is null)
            throw new BasketballStatsNotFoundException(query.Id);

        return new GetBasketballStatByIdResult(basketballStats.ToSingleBasketballStatsDto());
    }
}

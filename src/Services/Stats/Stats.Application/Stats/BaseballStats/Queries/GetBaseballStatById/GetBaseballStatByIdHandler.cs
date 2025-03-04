namespace Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatById;

public class GetBaseballStatByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBaseballStatByIdQuery, GetBaseballStatByIdResult>
{
    public async Task<GetBaseballStatByIdResult> Handle(GetBaseballStatByIdQuery query, CancellationToken cancellationToken)
    {
        // get baseball stat by id using dbContext
        // return result
        var baseballStatId = BaseballStatsId.Of(query.Id);
        var baseballStat = await dbContext.BaseballStats.FindAsync([baseballStatId], cancellationToken: cancellationToken);
        if (baseballStat is null)
            throw new BaseballStatsNotFoundException(query.Id);

        return new GetBaseballStatByIdResult(baseballStat.ToSingleBaseballStatsDto());
    }
}

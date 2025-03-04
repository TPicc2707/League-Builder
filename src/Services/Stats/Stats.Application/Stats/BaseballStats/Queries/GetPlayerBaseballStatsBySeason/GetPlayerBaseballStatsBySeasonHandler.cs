namespace Stats.Application.Stats.BaseballStats.Queries.GetPlayerBaseballStatsBySeason;

public class GetPlayerBaseballStatsBySeasonHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayerBaseballStatsBySeasonQuery, GetPlayerBaseballStatsBySeasonResult>
{
    public async Task<GetPlayerBaseballStatsBySeasonResult> Handle(GetPlayerBaseballStatsBySeasonQuery query, CancellationToken cancellationToken)
    {
        // get player baseball stats by season using dbContext
        // return result

        var baseballStats = await dbContext.BaseballStats.AsNoTracking()
                .Where(o => o.PlayerId == PlayerId.Of(query.PlayerId) && o.SeasonId == SeasonId.Of(query.SeasonId))
                .ToListAsync(cancellationToken);

        return new GetPlayerBaseballStatsBySeasonResult(baseballStats.ToBaseballStatsDtoList());
    }
}
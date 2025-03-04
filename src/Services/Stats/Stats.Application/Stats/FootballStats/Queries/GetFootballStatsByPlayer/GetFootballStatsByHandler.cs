namespace Stats.Application.Stats.FootballStats.Queries.GetFootballStatsByPlayer;

public class GetFootballStatsByPlayerHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetFootballStatsByPlayerQuery, GetFootballStatsByPlayerResult>
{
    public async Task<GetFootballStatsByPlayerResult> Handle(GetFootballStatsByPlayerQuery query, CancellationToken cancellationToken)
    {
        // get football stats by player using dbContext
        // return result

        var footballStats = await dbContext.FootballStats
        .AsNoTracking()
                .Where(o => o.PlayerId == PlayerId.Of(query.PlayerId))
                .ToListAsync(cancellationToken);

        return new GetFootballStatsByPlayerResult(footballStats.ToFootballStatsDtoList());
    }
}
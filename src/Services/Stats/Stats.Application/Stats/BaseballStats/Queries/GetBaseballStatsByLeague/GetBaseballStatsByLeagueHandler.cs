namespace Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatsByLeague;

public class GetBaseballStatsByLeagueHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBaseballStatsByLeagueQuery, GetBaseballStatsByLeagueResult>
{
    public async Task<GetBaseballStatsByLeagueResult> Handle(GetBaseballStatsByLeagueQuery query, CancellationToken cancellationToken)
    {
        // get baseball stats by league using dbContext
        // return result

        var baseballStats = await dbContext.BaseballStats
        .AsNoTracking()
                .Where(o => o.LeagueId == LeagueId.Of(query.LeagueId))
                .ToListAsync(cancellationToken);

        return new GetBaseballStatsByLeagueResult(baseballStats.ToBaseballStatsDtoList());
    }
}

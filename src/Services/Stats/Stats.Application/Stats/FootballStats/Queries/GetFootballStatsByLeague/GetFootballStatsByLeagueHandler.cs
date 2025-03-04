namespace Stats.Application.Stats.FootballStats.Queries.GetFootballStatsByLeague;

public class GetFootballStatsByLeagueHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetFootballStatsByLeagueQuery, GetFootballStatsByLeagueResult>
{
    public async Task<GetFootballStatsByLeagueResult> Handle(GetFootballStatsByLeagueQuery query, CancellationToken cancellationToken)
    {
        // get football stats by league using dbContext
        // return result

        var footballStats = await dbContext.FootballStats
        .AsNoTracking()
                .Where(o => o.LeagueId == LeagueId.Of(query.LeagueId))
                .ToListAsync(cancellationToken);

        return new GetFootballStatsByLeagueResult(footballStats.ToFootballStatsDtoList());
    }
}
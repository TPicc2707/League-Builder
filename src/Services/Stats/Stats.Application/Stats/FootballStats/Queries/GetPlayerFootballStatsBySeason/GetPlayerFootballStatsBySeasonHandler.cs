namespace Stats.Application.Stats.FootballStats.Queries.GetPlayerFootballStatsBySeason;

public class GetPlayerFootballStatsBySeasonHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayerFootballStatsBySeasonQuery, GetPlayerFootballStatsBySeasonResult>
{
    public async Task<GetPlayerFootballStatsBySeasonResult> Handle(GetPlayerFootballStatsBySeasonQuery query, CancellationToken cancellationToken)
    {
        // get player football stats by season using dbContext
        // return result

        var footballStats = await dbContext.FootballStats.AsNoTracking()
                .Where(o => o.PlayerId == PlayerId.Of(query.PlayerId) && o.SeasonId == SeasonId.Of(query.SeasonId))
                .ToListAsync(cancellationToken);

        return new GetPlayerFootballStatsBySeasonResult(footballStats.ToFootballStatsDtoList());
    }
}
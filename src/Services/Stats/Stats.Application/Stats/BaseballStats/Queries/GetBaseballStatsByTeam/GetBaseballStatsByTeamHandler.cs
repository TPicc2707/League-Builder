namespace Stats.Application.Stats.BaseballStats.Queries.GetBaseballStatsByTeam;

public class GetBaseballStatsByTeamHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBaseballStatsByTeamQuery, GetBaseballStatsByTeamResult>
{
    public async Task<GetBaseballStatsByTeamResult> Handle(GetBaseballStatsByTeamQuery query, CancellationToken cancellationToken)
    {
        // get baseball stats by team using dbContext
        // return result

        var baseballStats = await dbContext.BaseballStats
        .AsNoTracking()
                .Where(o => o.TeamId == TeamId.Of(query.TeamId))
                .ToListAsync(cancellationToken);

        return new GetBaseballStatsByTeamResult(baseballStats.ToBaseballStatsDtoList());
    }
}

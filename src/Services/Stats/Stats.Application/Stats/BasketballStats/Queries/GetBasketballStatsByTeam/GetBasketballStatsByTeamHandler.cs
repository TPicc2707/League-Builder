namespace Stats.Application.Stats.BasketballStats.Queries.GetBasketballStatsByTeam;

public class GetBasketballStatsByTeamHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBasketballStatsByTeamQuery, GetBasketballStatsByTeamResult>
{
    public async Task<GetBasketballStatsByTeamResult> Handle(GetBasketballStatsByTeamQuery query, CancellationToken cancellationToken)
    {
        // get basketball stats by team using dbContext
        // return result

        var basketballStats = await dbContext.BasketballStats
        .AsNoTracking()
                .Where(o => o.TeamId == TeamId.Of(query.TeamId))
                .ToListAsync(cancellationToken);

        return new GetBasketballStatsByTeamResult(basketballStats.ToBasketballStatsDtoList());
    }
}

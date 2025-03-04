namespace Stats.Application.Stats.FootballStats.Queries.GetFootballStatsById;

public class GetFootballStatByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetFootballStatByIdQuery, GetFootballStatByIdResult>
{
    public async Task<GetFootballStatByIdResult> Handle(GetFootballStatByIdQuery query, CancellationToken cancellationToken)
    {
        // get football stat by id using dbContext
        // return result
        var footballStatsId = FootballStatsId.Of(query.Id);
        var footballStats = await dbContext.FootballStats.FindAsync([footballStatsId], cancellationToken: cancellationToken);
        if (footballStats is null)
            throw new FootballStatsNotFoundException(query.Id);

        return new GetFootballStatByIdResult(footballStats.ToSingleFootballStatsDto());
    }
}

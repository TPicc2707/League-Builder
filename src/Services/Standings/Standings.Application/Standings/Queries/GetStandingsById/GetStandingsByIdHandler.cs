namespace Standings.Application.Standings.Queries.GetStandingsById;

public class GetStandingsByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetStandingsByIdQuery, GetStandingsByIdResult>
{
    public async Task<GetStandingsByIdResult> Handle(GetStandingsByIdQuery query, CancellationToken cancellationToken)
    {
        // get standings by id using dbContext
        // return result
        var standingsId = StandingsId.Of(query.Id);
        var standings = await dbContext.Standings.FindAsync([standingsId], cancellationToken: cancellationToken);
        if (standings is null)
            throw new StandingsNotFoundException(query.Id);

        return new GetStandingsByIdResult(standings.ToSingleStandingsDto());
    }
}


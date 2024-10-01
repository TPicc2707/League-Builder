namespace League.API.Leagues.GetLeaguesBySport;

public record GetLeaguesBySportQuery(string Sport) : IQuery<GetLeaguesBySportResult>;

public record GetLeaguesBySportResult(IEnumerable<Models.League> Leagues);

public class GetLeaguesBySportQueryHandler
    (IDocumentSession documentSession)
    : IQueryHandler<GetLeaguesBySportQuery, GetLeaguesBySportResult>
{
    public async Task<GetLeaguesBySportResult> Handle(GetLeaguesBySportQuery query, CancellationToken cancellationToken)
    {
        var leagues = await documentSession.Query<Models.League>()
            .Where(p => p.Sport == query.Sport)
            .ToListAsync();

        return new GetLeaguesBySportResult(leagues);
    }
}

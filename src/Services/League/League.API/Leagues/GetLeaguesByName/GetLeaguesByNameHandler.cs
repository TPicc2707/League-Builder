namespace League.API.Leagues.GetLeaguesByName;

public record GetLeaguesByNameQuery(string Name) : IQuery<GetLeaguesByNameResult>;

public record GetLeaguesByNameResult(IEnumerable<Models.League> Leagues);

public class GetLeaguesByNameQueryHandler
    (IDocumentSession documentSession)
    : IQueryHandler<GetLeaguesByNameQuery, GetLeaguesByNameResult>
{
    public async Task<GetLeaguesByNameResult> Handle(GetLeaguesByNameQuery query, CancellationToken cancellationToken)
    {
        var leagues = await documentSession.Query<Models.League>()
            .Where(p => p.Name.ToLower().Contains(query.Name.ToLower()))
            .ToListAsync();

        return new GetLeaguesByNameResult(leagues);
    }
}


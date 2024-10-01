namespace League.API.Leagues.GetLeagues;

public record GetLeaguesQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetLeaguesResult>;
public record GetLeaguesResult(IEnumerable<Models.League> Leagues);

public class GetLeaguesQueryHandler
    (IDocumentSession documentSession)
    : IQueryHandler<GetLeaguesQuery, GetLeaguesResult>
{
    public async Task<GetLeaguesResult> Handle(GetLeaguesQuery query, CancellationToken cancellationToken)
    {
        var products = await documentSession.Query<Models.League>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

        return new GetLeaguesResult(products);
    }
}


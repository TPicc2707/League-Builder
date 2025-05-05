namespace Season.API.Seasons.GetSeasons;

public record GetSeasonsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetSeasonsResult>;
public record GetSeasonsResult(IEnumerable<Models.Season> Seasons);


public class GetSeasonsHandler
    (IDocumentSession documentSession)
    : IQueryHandler<GetSeasonsQuery, GetSeasonsResult>
{
    public async Task<GetSeasonsResult> Handle(GetSeasonsQuery query, CancellationToken cancellationToken)
    {
        var products = await documentSession.Query<Models.Season>()
            .OrderByDescending(x => x.Year)
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

        return new GetSeasonsResult(products);
    }
}

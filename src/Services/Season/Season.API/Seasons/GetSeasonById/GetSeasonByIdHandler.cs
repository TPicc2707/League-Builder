namespace Season.API.Seasons.GetSeasonById;

public record GetSeasonByIdQuery(Guid Id) : IQuery<GetSeasonByIdResult>;

public record GetSeasonByIdResult(Models.Season Season);


public class GetSeasonByIdHandler
    (IDocumentSession documentSession)
    : IQueryHandler<GetSeasonByIdQuery, GetSeasonByIdResult>
{
    public async Task<GetSeasonByIdResult> Handle(GetSeasonByIdQuery query, CancellationToken cancellationToken)
    {
        var season = await documentSession.LoadAsync<Models.Season>(query.Id, cancellationToken);

        if (season is null)
        {
            throw new SeasonNotFoundException(query.Id);
        }

        return new GetSeasonByIdResult(season);
    }
}

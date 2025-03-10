namespace Season.API.Seasons.GetSeasonByYear;

public record GetSeasonByYearQuery(int Year) : IQuery<GetSeasonByYearResult>;

public record GetSeasonByYearResult(Models.Season Season);


public class GetSeasonByYearHandler
    (IDocumentSession documentSession)
    : IQueryHandler<GetSeasonByYearQuery, GetSeasonByYearResult>
{
    public async Task<GetSeasonByYearResult> Handle(GetSeasonByYearQuery query, CancellationToken cancellationToken)
    {
        var season = await documentSession.LoadAsync<Models.Season>(query.Year, cancellationToken);

        if (season is null)
        {
            throw new SeasonYearNotFoundException(query.Year);
        }

        return new GetSeasonByYearResult(season);
    }
}

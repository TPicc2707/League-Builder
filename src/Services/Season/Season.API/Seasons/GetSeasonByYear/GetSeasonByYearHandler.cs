namespace Season.API.Seasons.GetSeasonByYear;

public record GetSeasonByYearQuery(int Year) : IQuery<GetSeasonByYearResult>;

public record GetSeasonByYearResult(Models.Season Season);


public class GetSeasonByYearHandler
    (IDocumentSession documentSession)
    : IQueryHandler<GetSeasonByYearQuery, GetSeasonByYearResult>
{
    public async Task<GetSeasonByYearResult> Handle(GetSeasonByYearQuery query, CancellationToken cancellationToken)
    {
        var season = await documentSession.Query<Models.Season>().FirstOrDefaultAsync(x => x.Year == query.Year);

        if (season is null)
        {
            throw new SeasonYearNotFoundException(query.Year);
        }

        return new GetSeasonByYearResult(season);
    }
}

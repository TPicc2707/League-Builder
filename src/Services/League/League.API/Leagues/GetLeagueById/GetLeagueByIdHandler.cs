namespace League.API.Leagues.GetLeagueById;

public record GetLeagueByIdQuery(Guid Id) : IQuery<GetLeagueByIdResult>;

public record GetLeagueByIdResult(Models.League League);


public class GetLeagueByIdQueryHandler
    (IDocumentSession documentSession)
    : IQueryHandler<GetLeagueByIdQuery, GetLeagueByIdResult>
{
    public async Task<GetLeagueByIdResult> Handle(GetLeagueByIdQuery query, CancellationToken cancellationToken)
    {
        var league = await documentSession.LoadAsync<Models.League>(query.Id, cancellationToken);

        if (league is null)
        {
            throw new LeagueNotFoundException(query.Id);
        }

        return new GetLeagueByIdResult(league);
    }
}

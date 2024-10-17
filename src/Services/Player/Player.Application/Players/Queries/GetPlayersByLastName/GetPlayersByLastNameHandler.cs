namespace Player.Application.Players.Queries.GetPlayersByLastName;

public class GetPlayersByLastNameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayersByLastNameQuery, GetPlayersByLastNameResult>
{
    public async Task<GetPlayersByLastNameResult> Handle(GetPlayersByLastNameQuery query, CancellationToken cancellationToken)
    {
        //get players by last name using dbContext
        //return result

        var players = await dbContext.Players
                .AsNoTracking()
                .Where(o => o.LastName.Value.Contains(query.LastName))
                .OrderBy(o => o.FirstName.Value)
                .ThenBy(o => o.LastName.Value)
                .ToListAsync(cancellationToken);

        return new GetPlayersByLastNameResult(players.ToPlayerDtoList());
    }
}

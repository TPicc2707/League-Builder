namespace Player.Application.Players.Queries.GetPlayersByFirstName;

public class GetPlayersByFirstNameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayersByFirstNameQuery, GetPlayersByFirstNameResult>
{
    public async Task<GetPlayersByFirstNameResult> Handle(GetPlayersByFirstNameQuery query, CancellationToken cancellationToken)
    {
        //get players by first name using dbContext
        //return result

        var players = await dbContext.Players
                .AsNoTracking()
                .Where(o => o.FirstName.Value.Contains(query.FirstName))
                .OrderBy(o => o.FirstName.Value)
                .ThenBy(o => o.LastName.Value)
                .ToListAsync(cancellationToken);

        return new GetPlayersByFirstNameResult(players.ToPlayerDtoList());
    }
}

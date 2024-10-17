namespace Player.Application.Players.Queries.GetPlayersByPosition;

public class GetPlayersByPositionHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayersByPositionQuery, GetPlayersByPositionResult>
{
    public async Task<GetPlayersByPositionResult> Handle(GetPlayersByPositionQuery query, CancellationToken cancellationToken)
    {
        //get players by position using dbContext
        //return result

        var players = await dbContext.Players
                .AsNoTracking()
                .Where(o => o.PlayerDetail.Position.ToLower() == query.Position.ToLower())
                .OrderBy(o => o.FirstName.Value)
                .ThenBy(o => o.LastName.Value)
                .ToListAsync(cancellationToken);

        return new GetPlayersByPositionResult(players.ToPlayerDtoList());
    }
}

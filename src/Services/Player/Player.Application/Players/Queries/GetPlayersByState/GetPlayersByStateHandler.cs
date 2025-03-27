namespace Player.Application.Players.Queries.GetPlayersByState;

public class GetPlayersByStateHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayersByStateQuery, GetPlayersByStateResult>
{
    public async Task<GetPlayersByStateResult> Handle(GetPlayersByStateQuery query, CancellationToken cancellationToken)
    {
        //get players by state using dbContext
        //return result

        var players = await dbContext.Players
                .AsNoTracking()
                .Where(o => o.PlayerAddress.State.ToLower() == query.State.ToLower())
                .OrderBy(o => o.FirstName.Value)
                .ThenBy(o => o.LastName.Value)
                .ToListAsync(cancellationToken);

        return new GetPlayersByStateResult(players.ToPlayerDtoList());
    }
}

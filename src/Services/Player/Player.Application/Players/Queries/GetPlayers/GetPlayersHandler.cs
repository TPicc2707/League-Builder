namespace Player.Application.Players.Queries.GetPlayers;

public class GetPlayersHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayersQuery, GetPlayersResult>
{
    public async Task<GetPlayersResult> Handle(GetPlayersQuery query, CancellationToken cancellationToken)
    {
        //get players with pagination
        //return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Players.LongCountAsync(cancellationToken);

        var players = await dbContext.Players
                        .OrderBy(o => o.FirstName.Value)
                        .ThenBy(o => o.LastName.Value)
                        .Skip(pageSize * pageIndex)
                        .Take(pageSize)
                        .ToListAsync();

        return new GetPlayersResult(
            new PaginatedResult<PlayerDto>(
                pageIndex, pageSize, totalCount, players.ToPlayerDtoList()));
    }
}

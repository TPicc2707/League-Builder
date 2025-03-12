namespace Game.Application.Games.Queries.GetGames;

public class GetGamesHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetGamesQuery, GetGamesResult>
{
    public async Task<GetGamesResult> Handle(GetGamesQuery query, CancellationToken cancellationToken)
    {
        //get games with pagination
        //return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Games.LongCountAsync(cancellationToken);

        var games = await dbContext.Games
                        .Skip(pageSize * pageIndex)
                        .Take(pageSize)
                        .ToListAsync();

        return new GetGamesResult(
            new PaginatedResult<GameDto>(
                pageIndex, pageSize, totalCount, games.ToGameDtoList()));
    }
}

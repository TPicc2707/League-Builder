namespace Player.Application.Players.Queries.GetPlayersBeforeBirthDate;

public class GetPlayersBeforeBirthDateHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayersBeforeBirthDateQuery, GetPlayersBeforeBirthDateResult>
{
    public async Task<GetPlayersBeforeBirthDateResult> Handle(GetPlayersBeforeBirthDateQuery query, CancellationToken cancellationToken)
    {
        //get players before birth date using dbContext
        //return result

        var players = await dbContext.Players
                .AsNoTracking()
                .Where(o => o.PlayerDetail.BirthDate <= query.BirthDate)
                .OrderBy(o => o.FirstName.Value)
                .ThenBy(o => o.LastName.Value)
                .ToListAsync(cancellationToken);

        return new GetPlayersBeforeBirthDateResult(players.ToPlayerDtoList());
    }
}

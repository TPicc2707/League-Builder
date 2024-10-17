namespace Player.Application.Players.Queries.GetPlayersAfterBirthDate;

public class GetPlayersAfterBirthDateHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayersAfterBirthDateQuery, GetPlayersAfterBirthDateResult>
{
    public async Task<GetPlayersAfterBirthDateResult> Handle(GetPlayersAfterBirthDateQuery query, CancellationToken cancellationToken)
    {
        //get players after birth date using dbContext
        //return result

        var players = await dbContext.Players
                .AsNoTracking()
                .Where(o => o.PlayerDetail.BirthDate >= query.BirthDate)
                .OrderBy(o => o.FirstName.Value)
                .ThenBy(o => o.LastName.Value)
                .ToListAsync(cancellationToken);

        return new GetPlayersAfterBirthDateResult(players.ToPlayerDtoList());
    }
}

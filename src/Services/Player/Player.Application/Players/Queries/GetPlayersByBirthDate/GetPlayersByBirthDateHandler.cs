namespace Player.Application.Players.Queries.GetPlayersByBirthDate;

public class GetPlayersByBirthDateHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayersByBirthDateQuery, GetPlayersByBirthDateResult>
{
    public async Task<GetPlayersByBirthDateResult> Handle(GetPlayersByBirthDateQuery query, CancellationToken cancellationToken)
    {
        //get players by birth date using dbContext
        //return result

        var players = await dbContext.Players
                .AsNoTracking()
                .Where(o => o.PlayerDetail.BirthDate == query.BirthDate)
                .OrderBy(o => o.FirstName.Value)
                .ThenBy(o => o.LastName.Value)
                .ToListAsync(cancellationToken);

        return new GetPlayersByBirthDateResult(players.ToPlayerDtoList());
    }
}

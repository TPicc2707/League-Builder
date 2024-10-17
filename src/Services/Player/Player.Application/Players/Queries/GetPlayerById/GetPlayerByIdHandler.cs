namespace Player.Application.Players.Queries.GetPlayerById;

public class GetPlayerByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayerByIdQuery, GetPlayerByIdResult>
{
    public async Task<GetPlayerByIdResult> Handle(GetPlayerByIdQuery query, CancellationToken cancellationToken)
    {
        // get players by id using dbContext
        // return result
        var playerId = PlayerId.Of(query.Id);
        var player = await dbContext.Players.FindAsync([playerId], cancellationToken: cancellationToken);
        if (player is null)
            throw new TeamNotFoundException(query.Id);

        return new GetPlayerByIdResult(player.ToSingleTeamDto());
    }
}

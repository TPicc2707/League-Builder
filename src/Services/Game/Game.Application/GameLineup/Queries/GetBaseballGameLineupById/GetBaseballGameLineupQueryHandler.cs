namespace Game.Application.GameLineup.Queries.GetBaseballGameLineupById;

public class GetBaseballGameLineupQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBaseballGameLineupByIdQuery, GetBaseballGameLineupByIdResult>
{
    public async Task<GetBaseballGameLineupByIdResult> Handle(GetBaseballGameLineupByIdQuery query, CancellationToken cancellationToken)
    {
        var gameLineupId = GameLineupId.Of(query.Id);
        var gameLineup = await dbContext.GameLineups.FindAsync([gameLineupId], cancellationToken: cancellationToken);
        if (gameLineup is null)
            throw new GameLineupNotFoundException(query.Id);

        var team = await dbContext.Teams.FindAsync([gameLineup.TeamId], cancellationToken: cancellationToken);

        if (team is null)
            throw new TeamNotFoundException(gameLineup.TeamId.Value);

        return new GetBaseballGameLineupByIdResult(gameLineup.ToSingleBaseballGameLineupDto(team));
    }
}

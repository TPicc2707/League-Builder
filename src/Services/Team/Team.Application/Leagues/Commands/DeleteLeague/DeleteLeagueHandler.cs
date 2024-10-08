namespace Team.Application.Leagues.Commands.DeleteLeague;
public class DeleteLeagueHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteLeagueCommand, DeleteLeagueResult>
{
    public async Task<DeleteLeagueResult> Handle(DeleteLeagueCommand command, CancellationToken cancellationToken)
    {
        //Delete League enity from command object
        //save to database
        //return result

        var leagueId = LeagueId.Of(command.LeagueId);
        var league = await dbContext.Leagues
            .FindAsync([leagueId], cancellationToken: cancellationToken);

        if (league == null)
        {
            throw new LeagueNotFoundException(command.LeagueId);
        }

        dbContext.Leagues.Remove(league);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteLeagueResult(true);
    }
}

namespace Stats.Application.Stats.FootballStats.Commands.DeleteFootballStats;

public class DeleteFootballStatsHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteFootballStatsCommand, DeleteFootballStatsResult>
{
    public async Task<DeleteFootballStatsResult> Handle(DeleteFootballStatsCommand command, CancellationToken cancellationToken)
    {
        //Delete Football Stats enity from command object
        //save to database
        //return result

        var footballStatsId = BasketballStatsId.Of(command.FootballStatsId);
        var footballStats = await dbContext.FootballStats
            .FindAsync([footballStatsId], cancellationToken: cancellationToken);

        if (footballStats == null)
        {
            throw new FootballStatsNotFoundException(command.FootballStatsId);
        }

        dbContext.FootballStats.Remove(footballStats);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteFootballStatsResult(true);
    }
}

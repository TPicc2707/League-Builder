namespace Standings.Application.Standings.Commands.DeleteStandings;

public class DeleteStandingsHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteStandingsCommand, DeleteStandingsResult>
{
    public async Task<DeleteStandingsResult> Handle(DeleteStandingsCommand command, CancellationToken cancellationToken)
    {
        //Delete Standings enity from command object
        //save to database
        //return result

        var standingsId = StandingsId.Of(command.StandingsId);
        var standings = await dbContext.Standings
            .FindAsync([standingsId], cancellationToken: cancellationToken);

        if (standings == null)
        {
            throw new StandingsNotFoundException(command.StandingsId);
        }

        dbContext.Standings.Remove(standings);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteStandingsResult(true);
    }
}

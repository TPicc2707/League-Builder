namespace Game.Application.Leagues.Commands.UpdateLeague;

public class UpdateLeagueHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateLeagueCommand, UpdateLeagueResult>
{
    public async Task<UpdateLeagueResult> Handle(UpdateLeagueCommand command, CancellationToken cancellationToken)
    {
        //Update League entity from command object
        //save to database
        //return result

        var leagueId = LeagueId.Of(command.League.Id);
        var league = await dbContext.Leagues.FindAsync([leagueId], cancellationToken: cancellationToken);
        if (league is null)
            throw new LeagueNotFoundException(command.League.Id);

        UpdateLeagueWithNewValues(league, command.League);

        dbContext.Leagues.Update(league);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateLeagueResult(true);
    }

    private void UpdateLeagueWithNewValues(League league, LeagueDto leagueDto)
    {
        league.Update(
            leagueName: leagueDto.Name);
    }
}

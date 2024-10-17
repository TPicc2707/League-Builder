namespace Team.Application.Leagues.Commands.UpdateLeague;
public class UpdateLeagueHandler(IApplicationDbContext dbcontext)
    : ICommandHandler<UpdateLeagueCommand, UpdateLeagueResult>
{
    public async Task<UpdateLeagueResult> Handle(UpdateLeagueCommand command, CancellationToken cancellationToken)
    {
        //Update League entity from command object
        //save to database
        //return result

        var leagueId = LeagueId.Of(command.League.Id);
        var league = await dbcontext.Leagues.FindAsync([leagueId], cancellationToken: cancellationToken);
        if (league is null)
            throw new LeagueNotFoundException(command.League.Id);

        UpdateLeagueWithNewValues(league, command.League);

        dbcontext.Leagues.Update(league);
        await dbcontext.SaveChangesAsync(cancellationToken);

        return new UpdateLeagueResult(true);
    }

    private void UpdateLeagueWithNewValues(League league, LeagueDto leagueDto)
    {
        league.Update(
            name: leagueDto.Name,
            sport: Sport.Of(leagueDto.Sport),
            description: leagueDto.Description);
    }
}


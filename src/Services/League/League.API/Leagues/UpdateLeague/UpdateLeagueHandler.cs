namespace League.API.Leagues.UpdateLeague;

public record UpdateLeagueCommand(Guid Id, string Name, string Sport, string Description, string ImageFile)
    : ICommand<UpdateLeagueResult>;

public record UpdateLeagueResult(bool IsSuccess);

public class UpdateLeagueCommandHandler
    (IDocumentSession documentSession)
    : ICommandHandler<UpdateLeagueCommand, UpdateLeagueResult>
{
    public async Task<UpdateLeagueResult> Handle(UpdateLeagueCommand command, CancellationToken cancellationToken)
    {
        var league = await documentSession.LoadAsync<Models.League>(command.Id, cancellationToken);

        if (league == null)
        {
            throw new LeagueNotFoundException(command.Id);
        }

        league.Name = command.Name;
        league.Sport = command.Sport;
        league.Description = command.Description;
        league.ImageFile = command.ImageFile;
        league.Modified_DateTime = DateTime.Now;
        league.Modified_User = "tony.pic";

        documentSession.Update(league);
        await documentSession.SaveChangesAsync(cancellationToken);

        return new UpdateLeagueResult(true);
    }
}

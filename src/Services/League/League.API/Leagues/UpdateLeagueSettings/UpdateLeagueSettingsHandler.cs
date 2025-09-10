namespace League.API.Leagues.UpdateLeagueSettings;

public record UpdateLeagueSettingsCommand(Guid Id, int TotalGamesPerSeason, int TotalPlayoffTeams, int MinimumTotalTeamPlayers, int MaximumTotalTeamPlayers)
    : ICommand<UpdateLeagueSettingsResult>;

public record UpdateLeagueSettingsResult(bool IsSuccess);

public class UpdateLeagueCommandValidator : AbstractValidator<UpdateLeagueSettingsCommand>
{
    public UpdateLeagueCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("League Id is required");
        RuleFor(x => x.TotalGamesPerSeason).NotEmpty().GreaterThan(0).WithMessage("Total Games Per Season must be more than 0.");
        RuleFor(x => x.TotalGamesPerSeason).NotEmpty().LessThanOrEqualTo(60).WithMessage("Total Games Per Season can not be more than 60.");
        RuleFor(x => x.TotalPlayoffTeams).NotEmpty().GreaterThan(1).WithMessage("Total Playoff Teams must be more than 1.");
        RuleFor(x => x.TotalPlayoffTeams).NotEmpty().LessThanOrEqualTo(8).WithMessage("Total Playoff Teams can not be more than 8.");
        RuleFor(x => x.MinimumTotalTeamPlayers).NotEmpty().GreaterThanOrEqualTo(5).WithMessage("Teams must have a minimum of players.");
        RuleFor(x => x.MaximumTotalTeamPlayers).NotEmpty().LessThanOrEqualTo(30).WithMessage("Teams must have a minimum of players.");
        RuleFor(x => x.MaximumTotalTeamPlayers).NotEmpty().GreaterThanOrEqualTo(x => x.MinimumTotalTeamPlayers).WithMessage("Maximum number of players must be equal to or more than the minimum.");

    }
}

public class UpdateLeagueSettingsHandler
     (IDocumentSession documentSession)
    : ICommandHandler<UpdateLeagueSettingsCommand, UpdateLeagueSettingsResult>
{
    public async Task<UpdateLeagueSettingsResult> Handle(UpdateLeagueSettingsCommand command, CancellationToken cancellationToken)
    {
        var league = await documentSession.LoadAsync<Models.League>(command.Id, cancellationToken);

        if (league == null)
        {
            throw new LeagueNotFoundException(command.Id);
        }

        league.Name = league.Name;
        league.Sport = league.Sport;
        league.Description = league.Description;
        league.OwnerFirstName = league.OwnerFirstName;
        league.OwnerLastName = league.OwnerLastName;
        league.TotalGamesPerSeason = command.TotalGamesPerSeason;
        league.TotalPlayoffTeams = command.TotalPlayoffTeams;
        league.MinimumTotalTeamPlayers = command.MinimumTotalTeamPlayers;
        league.MaximumTotalTeamPlayers = command.MaximumTotalTeamPlayers;
        league.EmailAddress = league.EmailAddress;
        league.ImageFile = league.ImageFile;
        league.Modified_DateTime = DateTime.Now;
        league.Modified_User = "tony.pic";

        documentSession.Update(league);
        await documentSession.SaveChangesAsync(cancellationToken);

        return new UpdateLeagueSettingsResult(true);
    }
}

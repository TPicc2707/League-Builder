namespace League.API.Leagues.CreateLeague;

public record CreateLeagueCommand(string Name, string Sport, string Description, string OwnerFirstName, string OwnerLastName, string EmailAddress, string ImageFile)
    : ICommand<CreateLeagueResult>;

public record CreateLeagueResult(Guid Id);

public class CreateLeagueCommandValidator : AbstractValidator<CreateLeagueCommand>
{
    public CreateLeagueCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
            .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");
        RuleFor(x => x.Sport).NotEmpty().WithMessage("Sport is required");
        RuleFor(x => x.OwnerFirstName).NotEmpty().WithMessage("First Name is required")
            .Length(1, 15).WithMessage("First Name must be between 1 and 15 characters");
        RuleFor(x => x.OwnerLastName).NotEmpty().WithMessage("Last Name is required")
            .Length(1, 15).WithMessage("First Name must be between 1 and 15 characters");
        RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("Email Address is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
    }
}

internal class CreateLeagueCommandHandler
    (IDocumentSession documentSession, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CreateLeagueCommand, CreateLeagueResult>
{
    public async Task<CreateLeagueResult> Handle(CreateLeagueCommand command, CancellationToken cancellationToken)
    {
        // create League entity from command object
        // save to database
        // return CreateLeagueResult result

        var league = new Models.League
        {
            Name = command.Name,
            Sport = command.Sport,
            Description = command.Description,
            OwnerFirstName = command.OwnerFirstName,
            OwnerLastName = command.OwnerLastName,
            TotalGamesPerSeason = 0,
            TotalPlayoffTeams = 0,
            MinimumTotalTeamPlayers = 0,
            MaximumTotalTeamPlayers = 0,
            EmailAddress = command.EmailAddress,
            ImageFile = command.ImageFile,
            Created_DateTime = DateTime.Now,
            Created_User = "tony.pic",
            Modified_DateTime = DateTime.Now,
            Modified_User = "tony.pic"
        };

        // TODO
        // save to database
        documentSession.Store(league);
        await documentSession.SaveChangesAsync();

        var eventMessage = league.Adapt<LeagueCreationEvent>();

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        // return CreateLeagueResult result

        return new CreateLeagueResult(league.Id);
    }
}
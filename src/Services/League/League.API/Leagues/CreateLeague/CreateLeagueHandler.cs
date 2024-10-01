namespace League.API.Leagues.CreateLeague;

public record CreateLeagueCommand(string Name, string Sport, string Description, string ImageFile)
    : ICommand<CreateLeagueResult>;

public record CreateLeagueResult(Guid Id);

public class CreateLeagueCommandValidator : AbstractValidator<CreateLeagueCommand>
{
    public CreateLeagueCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
            .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");
        RuleFor(x => x.Sport).NotEmpty().WithMessage("Sport is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
    }
}

internal class CreateLeagueCommandHandler
    (IDocumentSession documentSession)
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

        // return CreateLeagueResult result

        return new CreateLeagueResult(league.Id);
    }
}
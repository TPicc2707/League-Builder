namespace Season.API.Seasons.CreateSeason;

public record CreateSeasonCommand(int Year, string Description)
    : ICommand<CreateSeasonResult>;

public record CreateSeasonResult(Guid Id);


public class CreateSeasonCommandValidator : AbstractValidator<CreateSeasonCommand>
{
    public CreateSeasonCommandValidator()
    {
        RuleFor(x => x.Year).NotEmpty().GreaterThanOrEqualTo(1850).WithMessage("Year is required and must be greater than the Year 1850");
    }
}

internal class CreateSeasonCommandHandler
    (IDocumentSession documentSession, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CreateSeasonCommand, CreateSeasonResult>
{
    public async Task<CreateSeasonResult> Handle(CreateSeasonCommand command, CancellationToken cancellationToken)
    {
        // create Season entity from command object
        // save to database
        // return CreateSeasonResult result

        var season = new Models.Season
        {
            Year = command.Year,
            Description = command.Description,
            Created_DateTime = DateTime.Now,
            Created_User = "tony.pic",
            Modified_DateTime = DateTime.Now,
            Modified_User = "tony.pic"
        };

        // TODO
        // save to database
        documentSession.Store(season);
        await documentSession.SaveChangesAsync();

        var eventMessage = season.Adapt<SeasonCreationEvent>();

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        // return CreateSeasonResult result

        return new CreateSeasonResult(season.Id);

    }
}

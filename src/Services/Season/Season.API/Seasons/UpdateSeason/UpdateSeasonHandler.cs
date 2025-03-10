namespace Season.API.Seasons.UpdateSeason;

public record UpdateSeasonCommand(Guid Id, int Year, string Description)
    : ICommand<UpdateSeasonResult>;

public record UpdateSeasonResult(bool IsSuccess);

public class UpdateSeasonCommandValidator : AbstractValidator<UpdateSeasonCommand>
{
    public UpdateSeasonCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("League Id is required");
        RuleFor(x => x.Year).NotEmpty().GreaterThanOrEqualTo(1850).WithMessage("Year is required and must be greater than the Year 1850");
    }
}


public class UpdateSeasonHandler
    (IDocumentSession documentSession, IPublishEndpoint publishEndpoint)
    : ICommandHandler<UpdateSeasonCommand, UpdateSeasonResult>
{
    public async Task<UpdateSeasonResult> Handle(UpdateSeasonCommand command, CancellationToken cancellationToken)
    {
        var season = await documentSession.LoadAsync<Models.Season>(command.Id, cancellationToken);

        if (season == null)
        {
            throw new SeasonNotFoundException(command.Id);
        }

        season.Year = command.Year;
        season.Description = command.Description;
        season.Modified_DateTime = DateTime.Now;
        season.Modified_User = "tony.pic";

        documentSession.Update(season);
        await documentSession.SaveChangesAsync(cancellationToken);

        var eventMessage = season.Adapt<SeasonUpdatedEvent>();

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        return new UpdateSeasonResult(true);
    }
}

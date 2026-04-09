namespace Season.API.Seasons.DeleteSeason;

public record DeleteSeasonCommand(Guid Id) : ICommand<DeleteSeasonResult>;
public record DeleteSeasonResult(bool IsSuccess);


public class DeleteSeasonCommandValidator : AbstractValidator<DeleteSeasonCommand>
{
    public DeleteSeasonCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Season Id is required");
    }
}

public class DeleteSeasonHandler
    (IDocumentSession documentSession, IBus _bus)
    : ICommandHandler<DeleteSeasonCommand, DeleteSeasonResult>
{
    public async Task<DeleteSeasonResult> Handle(DeleteSeasonCommand command, CancellationToken cancellationToken)
    {
        documentSession.Delete<Models.Season>(command.Id);
        await documentSession.SaveChangesAsync(cancellationToken);

        var eventMessage = new SeasonDeletionEvent()
        {
            Id = command.Id
        };

        await _bus.Publish(eventMessage);

        return new DeleteSeasonResult(true);
    }
}

namespace League.API.Leagues.DeleteLeague;

public record DeleteLeagueCommand(Guid Id) : ICommand<DeleteLeagueResult>;
public record DeleteLeagueResult(bool IsSuccess);

public class DeleteLeagueCommandValidator : AbstractValidator<DeleteLeagueCommand>
{
    public DeleteLeagueCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("League Id is required");
    }
}

public class DeleteLeagueCommandHandler
    (IDocumentSession documentSession)
    : ICommandHandler<DeleteLeagueCommand, DeleteLeagueResult>
{
    public async Task<DeleteLeagueResult> Handle(DeleteLeagueCommand command, CancellationToken cancellationToken)
    {
        documentSession.Delete<Models.League>(command.Id);
        await documentSession.SaveChangesAsync(cancellationToken);

        return new DeleteLeagueResult(true);
    }
}
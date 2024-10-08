namespace Team.Application.Leagues.Commands.DeleteLeague;

public record DeleteLeagueCommand(Guid LeagueId)
    : ICommand<DeleteLeagueResult>;

public record DeleteLeagueResult(bool IsSuccess);

public class DeleteLeagueCommandValidator : AbstractValidator<DeleteLeagueCommand>
{
    public DeleteLeagueCommandValidator()
    {
        RuleFor(x => x.LeagueId).NotEmpty().WithMessage("LeagueId is required");
    }
}
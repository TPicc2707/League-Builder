namespace Game.Application.GameLineup.Commands.DeleteBaseballGameLineup;

public record DeleteBaseballGameLineupCommand(Guid GameLineupId)
    : ICommand<DeleteBaseballGameLineupResult>;

public record DeleteBaseballGameLineupResult(bool IsSuccess);

public class DeleteBaseballGameLineupCommandValidator : AbstractValidator<DeleteBaseballGameLineupCommand>
{
    public DeleteBaseballGameLineupCommandValidator()
    {
        RuleFor(x => x.GameLineupId).NotEmpty().WithMessage("GameLineupId is required");
    }
}

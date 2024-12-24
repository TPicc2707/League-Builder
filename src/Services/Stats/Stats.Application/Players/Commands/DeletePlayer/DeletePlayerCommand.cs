namespace Stats.Application.Players.Commands.DeletePlayer;

public record DeletePlayerCommand(Guid PlayerId)
    : ICommand<DeletePlayerResult>;

public record DeletePlayerResult(bool IsSuccess);

public class DeletePlayerCommandValidator : AbstractValidator<DeletePlayerCommand>
{
    public DeletePlayerCommandValidator()
    {
        RuleFor(x => x.PlayerId).NotEmpty().WithMessage("PlayerId is required");
    }
}

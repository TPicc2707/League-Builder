namespace Game.Application.Games.Commands.DeleteGame;

public record DeleteGameCommand(Guid GameId)
    : ICommand<DeleteGameResult>;

public record DeleteGameResult(bool IsSuccess);

public class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand>
{
    public DeleteGameCommandValidator()
    {
        RuleFor(x => x.GameId).NotEmpty().WithMessage("GameId is required");
    }
}


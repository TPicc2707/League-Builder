namespace Stats.Application.Games.Commands.CreateGame;

public record CreateGameCommand(GameDto Game)
    : ICommand<CreateGameResult>;

public record CreateGameResult(Guid Id);

public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameCommandValidator()
    {
        RuleFor(x => x.Game.Id).NotEmpty().WithMessage("Id is required.");
    }
}
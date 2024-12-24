namespace Stats.Application.Games.Commands.UpdateGame;

public record UpdateGameCommand(GameDto Game)
    : ICommand<UpdateGameResult>;

public record UpdateGameResult(bool IsSuccess);

public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
{
    public UpdateGameCommandValidator()
    {
        RuleFor(x => x.Game.Id).NotEmpty().WithMessage("Id is required");
    }
}

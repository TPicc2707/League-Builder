namespace Stats.Application.Players.Commands.CreatePlayer;

public record CreatePlayerCommand(PlayerDto Player)
    : ICommand<CreatePlayerResult>;

public record CreatePlayerResult(Guid Id);

public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
{
    public CreatePlayerCommandValidator()
    {
        RuleFor(x => x.Player.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Player.FirstName).NotEmpty().WithMessage("FirstName is required.");
        RuleFor(x => x.Player.LastName).NotEmpty().WithMessage("LastName is required.");
    }
}

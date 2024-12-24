namespace Stats.Application.Players.Commands.UpdatePlayer;

public record UpdatePlayerCommand(PlayerDto Player)
    : ICommand<UpdatePlayerResult>;

public record UpdatePlayerResult(bool IsSuccess);

public class UpdatePlayerCommandValidator : AbstractValidator<UpdatePlayerCommand>
{
    public UpdatePlayerCommandValidator()
    {
        RuleFor(x => x.Player.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Player.FirstName).NotEmpty().WithMessage("FirstName is required");
        RuleFor(x => x.Player.LastName).NotEmpty().WithMessage("LastName is required");
    }
}

namespace Player.Application.Players.Commands.UpdatePlayer;

public record UpdatePlayerCommand(PlayerDto Player)
    : ICommand<UpdatePlayerResult>;

public record UpdatePlayerResult(bool IsSuccess);

public class UpdatePlayerCommandValidator : AbstractValidator<UpdatePlayerCommand>
{
    public UpdatePlayerCommandValidator()
    {
        RuleFor(x => x.Player.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Player.TeamId).NotEmpty().WithMessage("Team Id is required.");
        RuleFor(x => x.Player.FirstName).NotEmpty().WithMessage("First Name is required.");
        RuleFor(x => x.Player.LastName).NotEmpty().WithMessage("Last Name is required.");
        RuleFor(x => x.Player.PlayerDetail.BirthDate).NotEmpty().WithMessage("Birth Date is required.");
        RuleFor(x => x.Player.PlayerDetail.Position).NotEmpty().WithMessage("Position is required.");
        RuleFor(x => x.Player.PlayerDetail.Height).NotEmpty().GreaterThan(0).WithMessage("Height is required.");
        RuleFor(x => x.Player.PlayerDetail.Weight).NotEmpty().GreaterThan(0).WithMessage("Weight is required.");
    }
}

namespace Player.Application.Players.Commands.CreatePlayer;

public record CreatePlayerCommand(PlayerDto Player)
    : ICommand<CreatePlayerResult>;

public record CreatePlayerResult(Guid Id);

public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
{
    public CreatePlayerCommandValidator()
    {
        RuleFor(x => x.Player.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Player.TeamId).NotEmpty().WithMessage("Team Id is required.");
        RuleFor(x => x.Player.FirstName).NotEmpty().WithMessage("First Name is required.");
        RuleFor(x => x.Player.LastName).NotEmpty().WithMessage("Last Name is required.");
        RuleFor(x => x.Player.PlayerDetail.BirthDate).NotEmpty().WithMessage("Birth Date is required.");
        RuleFor(x => x.Player.PlayerDetail.Position).NotEmpty().WithMessage("Position is required.");
        RuleFor(x => x.Player.PlayerDetail.Height).NotEmpty().GreaterThan(0).WithMessage("Height is required.");
        RuleFor(x => x.Player.PlayerDetail.Weight).NotEmpty().GreaterThan(0).WithMessage("Weight is required.");
        RuleFor(x => x.Player.PlayerDetail.Number).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Number is required.");
    }
}
namespace Game.Application.GameLineup.Commands.CreateBaseballGameLineup;

public record CreateBaseballGameLineupCommand(GameLineupDto GameLineup)
    : ICommand<CreateBaseballGameLineupResult>;

public record CreateBaseballGameLineupResult(Guid Id);

public class CreateBaseballGameLineupCommandValidator : AbstractValidator<CreateBaseballGameLineupCommand>
{
    public CreateBaseballGameLineupCommandValidator()
    {
        RuleFor(x => x.GameLineup.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.GameLineup.GameId).NotEmpty().WithMessage("League Id is required.");
        RuleFor(x => x.GameLineup.TeamId).NotEmpty().WithMessage("Away Team Id is required.");
        RuleFor(x => x.GameLineup.BaseballLineup.First).NotEmpty().WithMessage("First Player Id is required.");
        RuleFor(x => x.GameLineup.BaseballLineup.Second).NotEmpty().WithMessage("Second Player Id is required.");
        RuleFor(x => x.GameLineup.BaseballLineup.Third).NotEmpty().WithMessage("Third Player Id is required.");
        RuleFor(x => x.GameLineup.BaseballLineup.Fourth).NotEmpty().WithMessage("Fourth Player Id is required.");
        RuleFor(x => x.GameLineup.BaseballLineup.Fifth).NotEmpty().WithMessage("Fifth Player Id is required.");
        RuleFor(x => x.GameLineup.BaseballLineup.Sixth).NotEmpty().WithMessage("Sixth Player Id is required.");
        RuleFor(x => x.GameLineup.BaseballLineup.Seventh).NotEmpty().WithMessage("Seventh Player Id is required.");
        RuleFor(x => x.GameLineup.BaseballLineup.Eighth).NotEmpty().WithMessage("Eighth Player Id is required.");
        RuleFor(x => x.GameLineup.BaseballLineup.Ninth).NotEmpty().WithMessage("Ninth Player Id is required.");
        RuleFor(x => x.GameLineup.BaseballLineup.StartingPitcher).NotEmpty().WithMessage("Starting Pitcher Player Id is required.");
    }
}
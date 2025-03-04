namespace Stats.Application.Stats.BasketballStats.Commands.UpdateBasketballStats;

public record UpdateBasketballStatsCommand(BasketballStatsDto BasketballStats)
    : ICommand<UpdateBasketballStatsResult>;

public record UpdateBasketballStatsResult(bool IsSuccess);

public class UpdateBasketballStatsCommandValidator : AbstractValidator<UpdateBasketballStatsCommand>
{
    public UpdateBasketballStatsCommandValidator()
    {
        RuleFor(x => x.BasketballStats.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.BasketballStats.LeagueId).NotEmpty().WithMessage("League Id is required.");
        RuleFor(x => x.BasketballStats.TeamId).NotEmpty().WithMessage("Team Id is required.");
        RuleFor(x => x.BasketballStats.PlayerId).NotEmpty().WithMessage("Player Id is required.");
        RuleFor(x => x.BasketballStats.SeasonId).NotEmpty().WithMessage("Season Id is required.");
        RuleFor(x => x.BasketballStats.GameId).NotEmpty().WithMessage("Game Id is required.");

        // Hitting
        RuleFor(x => x.BasketballStats.Stats.Start).NotEmpty().WithMessage("Start is required.");
        RuleFor(x => x.BasketballStats.Stats.Minutes).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Minutes is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.Points).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Points is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.FieldGoalsMade).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Field Goals Made is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.FieldGoalsAttempted).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Field Goals Attempted is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.FieldGoalPercentage).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Field Goal Percentage is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.ThreePointersMade).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Three Pointers Made is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.ThreePointersAttempted).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Three Pointers Attempted is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.ThreePointPercentage).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Three Point Percentage is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.FreeThrowsMade).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Free Throws Made is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.FreeThrowsAttempted).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Free Throws Attempted is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.FreeThrowPercentage).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Free Throw Percentage is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.Rebounds).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Rebounds is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.Assists).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Assists is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.Blocks).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Blocks is required and is greater than or equal to 0.");
        RuleFor(x => x.BasketballStats.Stats.Turnovers).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Turnovers is required and is greater than or equal to 0.");
    }
}

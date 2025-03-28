namespace Stats.Application.Stats.FootballStats.Commands.UpdateFootballStats;

public record UpdateFootballStatsCommand(FootballStatsDto FootballStats)
    : ICommand<UpdateFootballStatsResult>;

public record UpdateFootballStatsResult(bool IsSuccess);

public class UpdateFootballStatsCommandValidator : AbstractValidator<UpdateFootballStatsCommand>
{
    public UpdateFootballStatsCommandValidator()
    {
        RuleFor(x => x.FootballStats.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.FootballStats.LeagueId).NotEmpty().WithMessage("League Id is required.");
        RuleFor(x => x.FootballStats.TeamId).NotEmpty().WithMessage("Team Id is required.");
        RuleFor(x => x.FootballStats.PlayerId).NotEmpty().WithMessage("Player Id is required.");
        RuleFor(x => x.FootballStats.SeasonId).NotEmpty().WithMessage("Season Id is required.");
        RuleFor(x => x.FootballStats.GameId).NotEmpty().WithMessage("Game Id is required.");

        // Offensive Stats
        // Offensive Stats
        RuleFor(x => x.FootballStats.OffensiveStats.PassingCompletions).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Passing Completions is required.");
        RuleFor(x => x.FootballStats.OffensiveStats.PassingAttempts).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Passing Attempts is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.PassingYards).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Passing Yards Made is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.LongestPassingPlay).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Longest Passing Play is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.PassingTouchdowns).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Passing Touchdowns is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.PassingInterceptions).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Passing Interceptions Attempted is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.Sacks).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Sacks is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.RushingAttempts).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Rushing Attempts is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.RushingYards).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Rushing Yards is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.LongestRushingPlay).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Longest Rushing Play is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.RushingTouchdowns).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Rushing Touchdowns is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.RushingFumbles).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Rushing Fumbles is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.RushingFumblesLost).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Rushing Fumbles Lost is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.Receptions).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Receptions is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.ReceivingYards).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Receiving Yards is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.ReceivingTouchdowns).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Receiving Touchdowns is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.ReceivingFumbles).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Receiving Fumbles is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.ReceivingFumblesLost).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Receiving Fumbles Lost is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.OffensiveStats.YardsAfterCatch).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Yards After Catch is required and is greater than or equal to 0.");

        // Defensive Stats
        RuleFor(x => x.FootballStats.DefensiveStats.Tackles).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Tackles is required.");
        RuleFor(x => x.FootballStats.DefensiveStats.Sacks).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Sacks is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.DefensiveStats.TacklesForLoss).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Tackles For Loss is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.DefensiveStats.PassesDefended).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Passes Defended is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.DefensiveStats.DefensiveInterceptions).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Defensive Interceptions is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.DefensiveStats.DefensiveInterceptionYards).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Defensive Interception Yards is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.DefensiveStats.LongestDefensiveInterceptionPlay).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Longest Defensive Interception Play is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.DefensiveStats.DefensiveTouchdowns).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Defensive Touchdowns is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.DefensiveStats.ForcedFumbles).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Forced Fumbles is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.DefensiveStats.RecoveredFumbles).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Recovered Fumbles is required and is greater than or equal to 0.");

        // Kicking Stats
        RuleFor(x => x.FootballStats.KickingStats.FieldGoalsMade).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Field Goals Made is required.");
        RuleFor(x => x.FootballStats.KickingStats.FieldGoalsAttempted).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Field Goals Attempted is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.KickingStats.ExtraPointsMade).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Extra Points Made is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.KickingStats.ExtraPointsAttempted).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Extra Points Attempted is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.KickingStats.Punts).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Punts is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.KickingStats.PuntingYards).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Punting Yards is required and is greater than or equal to 0.");
        RuleFor(x => x.FootballStats.KickingStats.LongestPunt).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Longest Punt is required and is greater than or equal to 0.");

    }
}
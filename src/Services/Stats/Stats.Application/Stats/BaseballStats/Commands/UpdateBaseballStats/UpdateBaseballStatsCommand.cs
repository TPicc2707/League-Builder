namespace Stats.Application.Stats.BaseballStats.Commands.UpdateBaseballStats;

public record UpdateBaseballStatsCommand(BaseballStatsDto BaseballStats)
    : ICommand<UpdateBaseballStatsResult>;

public record UpdateBaseballStatsResult(bool IsSuccess);

public class UpdateBaseballStatsCommandValidator : AbstractValidator<UpdateBaseballStatsCommand>
{
    public UpdateBaseballStatsCommandValidator()
    {
        RuleFor(x => x.BaseballStats.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.BaseballStats.LeagueId).NotEmpty().WithMessage("League Id is required.");
        RuleFor(x => x.BaseballStats.TeamId).NotEmpty().WithMessage("Team Id is required.");
        RuleFor(x => x.BaseballStats.PlayerId).NotEmpty().WithMessage("Player Id is required.");
        RuleFor(x => x.BaseballStats.SeasonId).NotEmpty().WithMessage("Season Id is required.");
        RuleFor(x => x.BaseballStats.GameId).NotEmpty().WithMessage("Game Id is required.");

        // Hitting
        RuleFor(x => x.BaseballStats.HittingStats.AtBats).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("At Bats is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.Hits).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Hits is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.TotalBases).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Total Bases is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.Runs).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Runs is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.Doubles).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Doubles is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.Triples).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Triples is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.HomeRuns).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Home Runs is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.RunsBattedIn).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Runs Batted In is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.StolenBases).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Stolen Bases is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.Strikeouts).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Strikeouts is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.Walks).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Walks is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.Average).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Average is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.Slugging).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Slugging is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.OnBasePercentage).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("On Base Percentage is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.HittingStats.OnBasePlusSlugging).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("On Base Plus Slugging is required and is greater than or equal to 0.");

        //Pitching
        RuleFor(x => x.BaseballStats.PitchingStats.Wins).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Wins is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.PitchingStats.Losses).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Losses is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.PitchingStats.Start).NotEmpty().WithMessage("Start is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.PitchingStats.Saves).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Saves is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.PitchingStats.Innings).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Innings is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.PitchingStats.HitsAllowed).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Hits Allowed is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.PitchingStats.WalksAllowed).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Walks Allowed is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.PitchingStats.PitchingStrikeouts).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Pitching Strikeouts is required and is greater than or equal to 0.");
        RuleFor(x => x.BaseballStats.PitchingStats.WalksHitsPerInning).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Walks Hits Per Inning is required and is greater than or equal to 0.");
    }
}

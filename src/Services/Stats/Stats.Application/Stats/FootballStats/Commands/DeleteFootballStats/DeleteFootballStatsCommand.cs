namespace Stats.Application.Stats.FootballStats.Commands.DeleteFootballStats;

public record DeleteFootballStatsCommand(Guid FootballStatsId)
    : ICommand<DeleteFootballStatsResult>;


public record DeleteFootballStatsResult(bool IsSuccess);

public class DeleteFootballStatsCommandValidator : AbstractValidator<DeleteFootballStatsCommand>
{
    public DeleteFootballStatsCommandValidator()
    {
        RuleFor(x => x.FootballStatsId).NotEmpty().WithMessage("FootballStatsId is required");
    }
}

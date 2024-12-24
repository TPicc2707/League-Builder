namespace Stats.Application.Stats.BaseballStats.Commands.DeleteBaseballStats;

public record DeleteBaseballStatsCommand(Guid BaseballStatsId)
    : ICommand<DeleteBaseballStatsResult>;

public record DeleteBaseballStatsResult(bool IsSuccess);

public class DeleteBaseballStatsCommandValidator : AbstractValidator<DeleteBaseballStatsCommand>
{
    public DeleteBaseballStatsCommandValidator()
    {
        RuleFor(x => x.BaseballStatsId).NotEmpty().WithMessage("BaseballStatsId is required");
    }
}

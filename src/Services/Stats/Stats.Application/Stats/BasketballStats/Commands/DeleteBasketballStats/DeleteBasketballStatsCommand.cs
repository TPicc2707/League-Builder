namespace Stats.Application.Stats.BasketballStats.Commands.DeleteBasketballStats;

public record DeleteBasketballStatsCommand(Guid BasketballStatsId)
    : ICommand<DeleteBasketballStatsResult>;


public record DeleteBasketballStatsResult(bool IsSuccess);

public class DeleteBasketballStatsCommandValidator : AbstractValidator<DeleteBasketballStatsCommand>
{
	public DeleteBasketballStatsCommandValidator()
	{
		RuleFor(x => x.BasketballStatsId).NotEmpty().WithMessage("BasketballStatsId is required");
	}
}
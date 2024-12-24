namespace Stats.Application.Seasons.Commands.DeleteSeason;

public record DeleteSeasonCommand(Guid SeasonId)
    : ICommand<DeleteSeasonResult>;

public record DeleteSeasonResult(bool IsSuccess);

public class DeleteSeasonCommandValidator : AbstractValidator<DeleteSeasonCommand>
{
    public DeleteSeasonCommandValidator()
    {
        RuleFor(x => x.SeasonId).NotEmpty().WithMessage("SeasonId is required");
    }
}

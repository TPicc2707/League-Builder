namespace Stats.Application.Seasons.Commands.UpdateSeason;

public record UpdateSeasonCommand(SeasonDto Season)
    : ICommand<UpdateSeasonResult>;

public record UpdateSeasonResult(bool IsSuccess);

public class UpdateSeasonCommandValidator : AbstractValidator<UpdateSeasonCommand>
{
    public UpdateSeasonCommandValidator()
    {
        RuleFor(x => x.Season.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Season.Year).NotEmpty().WithMessage("Year is required");
    }
}

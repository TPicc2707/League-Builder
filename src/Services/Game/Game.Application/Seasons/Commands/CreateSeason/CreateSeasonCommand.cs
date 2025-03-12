namespace Game.Application.Seasons.Commands.CreateSeason;

public record CreateSeasonCommand(SeasonDto Season)
    : ICommand<CreateSeasonResult>;

public record CreateSeasonResult(Guid Id);

public class CreateSeasonCommandValidator : AbstractValidator<CreateSeasonCommand>
{
    public CreateSeasonCommandValidator()
    {
        RuleFor(x => x.Season.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Season.Year).NotEmpty().WithMessage("Year is required.");
    }
}

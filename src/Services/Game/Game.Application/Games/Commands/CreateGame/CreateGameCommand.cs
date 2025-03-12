namespace Game.Application.Games.Commands.CreateGame;

public record CreateGameCommand(GameDto Game)
    : ICommand<CreateGameResult>;

public record CreateGameResult(Guid Id);

public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameCommandValidator()
    {
        RuleFor(x => x.Game.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Game.LeagueId).NotEmpty().WithMessage("League Id is required.");
        RuleFor(x => x.Game.AwayTeamId).NotEmpty().WithMessage("Away Team Id is required.");
        RuleFor(x => x.Game.HomeTeamId).NotEmpty().WithMessage("Home Team Id is required.");
        RuleFor(x => x.Game.SeasonId).NotEmpty().WithMessage("Season Id is required.");
        RuleFor(x => x.Game.GameDetail.AwayTeamScore).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Away Team Score is required.");
        RuleFor(x => x.Game.GameDetail.HomeTeamScore).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Home Team Score is required.");
        RuleFor(x => x.Game.GameDetail.StartTime).NotEmpty().WithMessage("Start Time is required.");
    }
}

namespace Game.Application.Games.Commands.UpdateGame;

public record UpdateGameCommand(GameDto Game)
    : ICommand<UpdateGameResult>;

public record UpdateGameResult(bool IsSuccess);

public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
{
    public UpdateGameCommandValidator()
    {
        RuleFor(x => x.Game.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Game.LeagueId).NotEmpty().WithMessage("League Id is required.");
        RuleFor(x => x.Game.AwayTeam.Id).NotEmpty().WithMessage("Away Team Id is required.");
        RuleFor(x => x.Game.HomeTeam.Id).NotEmpty().WithMessage("Home Team Id is required.");
        RuleFor(x => x.Game.SeasonId).NotEmpty().WithMessage("Season Id is required.");
        RuleFor(x => x.Game.GameDetail.AwayTeamScore).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Away Team Score is required.");
        RuleFor(x => x.Game.GameDetail.HomeTeamScore).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Home Team Score is required.");
        RuleFor(x => x.Game.GameDetail.StartTime).NotEmpty().WithMessage("Start Time is required.");
    }
}

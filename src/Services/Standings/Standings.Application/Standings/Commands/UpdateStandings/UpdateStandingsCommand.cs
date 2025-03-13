namespace Standings.Application.Standings.Commands.UpdateStandings;

public record UpdateStandingsCommand(StandingsDto Standings)
    : ICommand<UpdateStandingsResult>;

public record UpdateStandingsResult(bool IsSuccess);

public class UpdateGameCommandValidator : AbstractValidator<UpdateStandingsCommand>
{
    public UpdateGameCommandValidator()
    {
        RuleFor(x => x.Standings.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Standings.LeagueId).NotEmpty().WithMessage("League Id is required.");
        RuleFor(x => x.Standings.TeamId).NotEmpty().WithMessage("Team Id is required.");
        RuleFor(x => x.Standings.SeasonId).NotEmpty().WithMessage("Season Id is required.");
        RuleFor(x => x.Standings.StandingsDetail.GamesPlayed).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Games Played is required.");
        RuleFor(x => x.Standings.StandingsDetail.Wins).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Wins is required.");
        RuleFor(x => x.Standings.StandingsDetail.Losses).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Losses is required.");
        RuleFor(x => x.Standings.StandingsDetail.Ties).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Ties is required.");
    }
}

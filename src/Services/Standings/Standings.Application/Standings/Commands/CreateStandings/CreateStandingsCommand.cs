namespace Standings.Application.Standings.Commands.CreateStandings;

public record CreateStandingsCommand(StandingsDto Standings)
    : ICommand<CreateStandingsResult>;

public record CreateStandingsResult(Guid Id);

public class CreateStandingsCommandValidator : AbstractValidator<CreateStandingsCommand>
{
    public CreateStandingsCommandValidator()
    {
        RuleFor(x => x.Standings.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Standings.LeagueId).NotEmpty().WithMessage("League Id is required.");
        RuleFor(x => x.Standings.Team.Id).NotEmpty().WithMessage("Team Id is required.");
        RuleFor(x => x.Standings.SeasonId).NotEmpty().WithMessage("Season Id is required.");
        RuleFor(x => x.Standings.StandingsDetail.GamesPlayed).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Games Played is required.");
        RuleFor(x => x.Standings.StandingsDetail.Wins).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Wins is required.");
        RuleFor(x => x.Standings.StandingsDetail.Losses).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Losses is required.");
        RuleFor(x => x.Standings.StandingsDetail.Ties).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Ties is required.");
    }
}

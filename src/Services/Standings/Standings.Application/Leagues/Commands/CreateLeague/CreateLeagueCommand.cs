namespace Standings.Application.Leagues.Commands.CreateLeague;

public record CreateLeagueCommand(LeagueDto League)
    : ICommand<CreateLeagueResult>;

public record CreateLeagueResult(Guid Id);

public class CreateLeagueCommandValidator : AbstractValidator<CreateLeagueCommand>
{
    public CreateLeagueCommandValidator()
    {
        RuleFor(x => x.League.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.League.Name).NotEmpty().WithMessage("Name is required.");
    }
}
namespace Game.Application.Leagues.Commands.UpdateLeague;

public record UpdateLeagueCommand(LeagueDto League)
    : ICommand<UpdateLeagueResult>;

public record UpdateLeagueResult(bool IsSuccess);

public class UpdateLeagueCommandValidator : AbstractValidator<UpdateLeagueCommand>
{
    public UpdateLeagueCommandValidator()
    {
        RuleFor(x => x.League.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.League.Name).NotEmpty().WithMessage("Name is required");
    }
}
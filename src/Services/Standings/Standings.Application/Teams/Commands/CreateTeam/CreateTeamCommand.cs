namespace Standings.Application.Teams.Commands.CreateTeam;

public record CreateTeamCommand(TeamDto Team)
    : ICommand<CreateTeamResult>;

public record CreateTeamResult(Guid Id);

public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
{
    public CreateTeamCommandValidator()
    {
        RuleFor(x => x.Team.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Team.TeamName).NotEmpty().WithMessage("TeamName is required.");
    }
}

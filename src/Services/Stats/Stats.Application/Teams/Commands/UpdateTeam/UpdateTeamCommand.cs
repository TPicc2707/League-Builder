namespace Stats.Application.Teams.Commands.UpdateTeam;

public record UpdateTeamCommand(TeamDto Team)
    : ICommand<UpdateTeamResult>;

public record UpdateTeamResult(bool IsSuccess);

public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
{
    public UpdateTeamCommandValidator()
    {
        RuleFor(x => x.Team.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Team.TeamName).NotEmpty().WithMessage("Name is required");
    }
}

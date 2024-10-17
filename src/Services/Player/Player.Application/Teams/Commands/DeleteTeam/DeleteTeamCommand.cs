namespace Player.Application.Teams.Commands.DeleteTeam;

public record DeleteTeamCommand(Guid TeamId)
    : ICommand<DeleteTeamResult>;

public record DeleteTeamResult(bool IsSuccess);

public class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
{
    public DeleteTeamCommandValidator()
    {
        RuleFor(x => x.TeamId).NotEmpty().WithMessage("TeamId is required");
    }
}
namespace Standings.Application.Standings.Commands.DeleteStandings;

public record DeleteStandingsCommand(Guid StandingsId)
    : ICommand<DeleteStandingsResult>;

public record DeleteStandingsResult(bool IsSuccess);

public class DeleteGameCommandValidator : AbstractValidator<DeleteStandingsCommand>
{
    public DeleteGameCommandValidator()
    {
        RuleFor(x => x.StandingsId).NotEmpty().WithMessage("StandingsId is required");
    }
}


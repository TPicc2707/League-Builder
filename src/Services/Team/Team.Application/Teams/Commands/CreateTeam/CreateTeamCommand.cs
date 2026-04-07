namespace Team.Application.Teams.Commands.CreateTeam;

public record CreateTeamCommand(TeamDto Team)
    : ICommand<CreateTeamResult>;

public record CreateTeamResult(Guid Id);

public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
{
    public CreateTeamCommandValidator()
    {
        RuleFor(x => x.Team.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Team.LeagueId).NotEmpty().WithMessage("League Id is required.");
        RuleFor(x => x.Team.TeamName).NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
        RuleFor(x => x.Team.TeamAddress.FirstName).NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
        RuleFor(x => x.Team.TeamAddress.LastName).NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
        RuleFor(x => x.Team.TeamAddress.AddressLine).NotEmpty().WithMessage("Address is required.");
        RuleFor(x => x.Team.TeamAddress.City).NotEmpty().WithMessage("City is required.")
                .Length(2, 50).WithMessage("City must be between 2 and 50 characters");
        RuleFor(x => x.Team.TeamAddress.State).NotEmpty().WithMessage("State is required.");
        RuleFor(x => x.Team.TeamAddress.Country).NotEmpty().WithMessage("Country is required.");
        RuleFor(x => x.Team.TeamAddress.ZipCode).NotEmpty().WithMessage("Zip Code is required.");
        RuleFor(x => x.Team.TeamAddress.ZipCode).Matches(@"^\d{5}(-\d{4})?$").WithMessage("A valid Zip Code is required.");
        RuleFor(x => x.Team.TeamAddress.EmailAddress).NotEmpty().WithMessage("Email Address is required")
                .EmailAddress().WithMessage("A valid Email Address is required");
        RuleFor(x => x.Team.ImageFile).NotEmpty().WithMessage("File is required");
        RuleFor(x => x.Team.TeamColor).NotEmpty().WithMessage("Team Color is required.");
        RuleFor(x => x.Team.TeamManager.FirstName).NotEmpty().WithMessage("Manager First Name is required.")
        .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
        RuleFor(x => x.Team.TeamManager.LastName).NotEmpty().WithMessage("Manager Last Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
        RuleFor(x => x.Team.TeamManager.EmailAddress).NotEmpty().WithMessage("Manager Email Address is required")
        .EmailAddress().WithMessage("A valid Email Address is required");
    }
}

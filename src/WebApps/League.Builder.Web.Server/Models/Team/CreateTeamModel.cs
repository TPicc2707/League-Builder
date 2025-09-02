using FluentValidation;

namespace League.Builder.Web.Server.Models.Team;

public class CreateTeamModel
{
    public string TeamName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string AddressLine { get; set; }

    public string EmailAddress { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public string ZipCode { get; set; }

    public string Description { get; set; }

    public string ImageFile { get; set; }

    public IBrowserFile File { get; set; }

    public TeamStatus TeamStatus { get; set; }
}


public class CreateTeamModelValidator : AbstractValidator<CreateTeamModel>
{
    public CreateTeamModelValidator()
    {
        RuleFor(x => x.TeamName).NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
        RuleFor(x => x.AddressLine).NotEmpty().WithMessage("Address is required.");
        RuleFor(x => x.State).NotEmpty().WithMessage("State is required.");
        RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");
        RuleFor(x => x.ZipCode).NotEmpty().WithMessage("Zip Code is required.");
        RuleFor(x => x.ZipCode).Matches(@"^\d{5}(-\d{4})?$").WithMessage("A valid Zip Code is required.");
        RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("Email Address is required");
        RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("A valid Email Address is required");
        RuleFor(x => x.File).NotEmpty().WithMessage("File is required");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateTeamModel>.CreateWithOptions((CreateTeamModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
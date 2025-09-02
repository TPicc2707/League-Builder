using FluentValidation;

namespace League.Builder.Web.Server.Models.League;

public class CreateLeagueModel
{
    public string Name { get; set; }

    public string Sport { get; set; }

    public string OwnerFirstName { get; set; }

    public string OwnerLastName { get; set; }

    public string EmailAddress { get; set; }

    public string Description { get; set; }

    public string ImageFile { get; set; }

    public IBrowserFile File { get; set; }
}


/// <summary>
/// A standard AbstractValidator which contains multiple rules and can be shared with the back end API
/// </summary>
/// <typeparam name="CreateLeagueModel"></typeparam>
public class CreateLeagueModelValidator : AbstractValidator<CreateLeagueModel>
{
    public CreateLeagueModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
             .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");
        RuleFor(x => x.Sport).NotEmpty().WithMessage("Sport is required");
        RuleFor(x => x.OwnerFirstName).NotEmpty().WithMessage("First Name is required")
            .Length(1, 15).WithMessage("First Name must be between 1 and 15 characters");
        RuleFor(x => x.OwnerLastName).NotEmpty().WithMessage("Last Name is required")
            .Length(1, 15).WithMessage("First Name must be between 1 and 15 characters");
        RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("Email Address is required");
        RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("A valid Email Address is required");
        RuleFor(x => x.File).NotEmpty().WithMessage("File is required");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateLeagueModel>.CreateWithOptions((CreateLeagueModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}

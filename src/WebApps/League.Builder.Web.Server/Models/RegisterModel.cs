namespace League.Builder.Web.Server.Models;

public class RegisterModel
{
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}


public class RegisterModelValidator : AbstractValidator<RegisterModel>
{
    public RegisterModelValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email Address is required");
        RuleFor(x => x.Email).EmailAddress().WithMessage("A valid Email Address is required");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required")
             .Length(1, 15).WithMessage("First Name must be between 1 and 15 characters");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required")
            .Length(1, 15).WithMessage("First Name must be between 1 and 15 characters");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<RegisterModel>.CreateWithOptions((RegisterModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
using FluentValidation;

namespace League.Builder.Web.Server.Models.Player;

public class UpdatePlayerModel
{
    public Guid Id { get; set; }

    public Guid TeamId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string AddressLine { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public string ZipCode { get; set; }

    public string EmailAddress { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime? BirthDate { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    public int Number { get; set; }

    public string Position { get; set; }

    public string Description { get; set; }

    public string ImageFile { get; set; }

    public IBrowserFile File { get; set; }


    public PlayerStatus PlayerStatus { get; set; }

}

public class UpdatePlayerModelValidator : AbstractValidator<UpdatePlayerModel>
{
    public UpdatePlayerModelValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters");
        RuleFor(x => x.AddressLine).NotEmpty().WithMessage("Address is required.");
        RuleFor(x => x.State).NotEmpty().WithMessage("State is required.");
        RuleFor(x => x.City).NotEmpty().WithMessage("City is required.")
               .Length(2, 50).WithMessage("City must be between 2 and 50 characters"); 
        RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");
        RuleFor(x => x.ZipCode).NotEmpty().WithMessage("Zip Code is required.");
        RuleFor(x => x.ZipCode).Matches(@"^\d{5}(-\d{4})?$").WithMessage("A valid Zip Code is required.");
        RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("Email Address is required");
        RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("A valid Email Address is required");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone Number is required");
        RuleFor(x => x.PhoneNumber).Matches(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").WithMessage("A valid Phone Number is required");
        RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Birth Date is required");
        RuleFor(x => x.Height).NotEmpty().WithMessage("Height is required").InclusiveBetween(48, 96).WithMessage("A valid Height is required");
        RuleFor(x => x.Weight).NotEmpty().WithMessage("Weight is required").InclusiveBetween(75, 450).WithMessage("A valid Weight is required");
        RuleFor(x => x.Number).NotEmpty().WithMessage("Number is required").InclusiveBetween(0, 100).WithMessage("A valid Number is required");
        RuleFor(x => x.Position).NotEmpty().WithMessage("Position is required");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<UpdatePlayerModel>.CreateWithOptions((UpdatePlayerModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
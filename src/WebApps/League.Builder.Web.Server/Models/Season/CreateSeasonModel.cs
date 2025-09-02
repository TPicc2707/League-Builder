using FluentValidation;

namespace League.Builder.Web.Server.Models.Season;

public class CreateSeasonModel
{
    public int Year { get; set; } = DateTime.Now.Year;
    public string Description { get; set; } = default!;

}


public class CreateSeasonModelValidator : AbstractValidator<CreateSeasonModel>
{
    public CreateSeasonModelValidator()
    {
        RuleFor(x => x.Year).NotEmpty().WithMessage("Please enter valid Year.").InclusiveBetween(DateTime.Now.Year - 30, DateTime.Now.Year + 30).WithMessage("The season must be a more recent year.");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateSeasonModel>.CreateWithOptions((CreateSeasonModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}

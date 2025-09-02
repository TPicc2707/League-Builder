using FluentValidation;

namespace League.Builder.Web.Server.Models.Game;

public class CreateGameModel
{
    public Guid AwayTeamId { get; set; }
    public Guid HomeTeamId { get; set; }
    public DateTime? StartDate { get; set; }
    public TimeSpan? StartTime { get; set; }
}


public class CreateGameModelValidator : AbstractValidator<CreateGameModel>
{
    public CreateGameModelValidator()
    {
        RuleFor(x => x.StartDate).NotEmpty().WithMessage("Start Date is required.");
        RuleFor(x => x.StartTime).NotEmpty().WithMessage("Start Time is required.");
        RuleFor(x => x.HomeTeamId).NotEqual(x => x.AwayTeamId).WithMessage("Home & Away Team must be different.");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateGameModel>.CreateWithOptions((CreateGameModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
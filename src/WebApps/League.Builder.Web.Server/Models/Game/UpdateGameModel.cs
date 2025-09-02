using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace League.Builder.Web.Server.Models.Game;

public class UpdateGameModel
{
    public Guid LeagueId { get; set; }
    public Guid AwayTeamId { get; set; }
    public Guid HomeTeamId { get; set; }
    public Guid WinningTeamId { get; set; }
    public DateTime? StartDate { get; set; }
    public TimeSpan? StartTime { get; set; }
    public DateTime? EndDate { get; set; }
    public TimeSpan? EndTime { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Away Team Score")]
    public int AwayTeamScore { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Home Team Score")]
    public int HomeTeamScore { get; set; }

    public GameStatus GameStatus { get; set; }
}

public class UpdateGameModelValidator : AbstractValidator<UpdateGameModel>
{
    public UpdateGameModelValidator()
    {
        RuleFor(x => x.StartDate).NotEmpty().WithMessage("Start Date is required.");
        RuleFor(x => x.StartTime).NotEmpty().WithMessage("Start Time is required.");
        RuleFor(x => x.HomeTeamId).NotEqual(x => x.AwayTeamId).WithMessage("Home & Away Team must be different.");
        RuleFor(x => x.WinningTeamId).NotEmpty().When(x => x.GameStatus == GameStatus.Completed).WithMessage("Game is Completed, please select a winner!");
        RuleFor(x => x.EndDate).NotEmpty().When(x => x.GameStatus == GameStatus.Completed).WithMessage("End Date is required.");
        RuleFor(x => x.EndTime).NotEmpty().When(x => x.GameStatus == GameStatus.Completed).WithMessage("End Time is required.");
        RuleFor(x => x.HomeTeamScore).NotEqual(x => x.AwayTeamScore).When(x => x.GameStatus == GameStatus.Completed).WithMessage("Scores cant be the same.");
        RuleFor(x => x.HomeTeamScore).GreaterThan(x => x.AwayTeamScore).When(x => x.GameStatus == GameStatus.Completed && x.WinningTeamId == x.HomeTeamId).WithMessage("Winning Team must have more than the losing team.");
        RuleFor(x => x.AwayTeamScore).GreaterThan(x => x.HomeTeamScore).When(x => x.GameStatus == GameStatus.Completed && x.WinningTeamId == x.AwayTeamId).WithMessage("Winning Team must have more than the losing team.");

    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<UpdateGameModel>.CreateWithOptions((UpdateGameModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
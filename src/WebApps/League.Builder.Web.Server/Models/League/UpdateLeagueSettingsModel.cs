using FluentValidation;

namespace League.Builder.Web.Server.Models.League;

public class UpdateLeagueSettingsModel
{
    public Guid Id { get; set; }

    public int? TotalGamesPerSeason { get; set; }

    public int? TotalPlayoffTeams { get; set; }
    public int? MinimumTotalTeamPlayers { get; set; }
    public int? MaximumTotalTeamPlayers { get; set; }
}

/// <summary>
/// A standard AbstractValidator which contains multiple rules and can be shared with the back end API
/// </summary>
/// <typeparam name="UpdateLeagueSettingsModel"></typeparam>
public class UpdateLeagueSettingsModelValidator : AbstractValidator<UpdateLeagueSettingsModel>
{
    public UpdateLeagueSettingsModelValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("League Id is required");
        RuleFor(x => x.TotalGamesPerSeason).NotEmpty().WithMessage("Total Games must not be empty");
        RuleFor(x => x.TotalGamesPerSeason).GreaterThan(0).WithMessage("Total Games Per Season must be more than 0.");
        RuleFor(x => x.TotalGamesPerSeason).LessThanOrEqualTo(60).WithMessage("Total Games Per Season can not be more than 60.");
        RuleFor(x => x.TotalPlayoffTeams).NotEmpty().WithMessage("Total Playoff Teams must not be empty");
        RuleFor(x => x.TotalPlayoffTeams).GreaterThan(1).WithMessage("Total Playoff Teams must be more than 1.");
        RuleFor(x => x.TotalPlayoffTeams).LessThanOrEqualTo(8).WithMessage("Total Playoff Teams can not be more than 8.");
        RuleFor(x => x.MinimumTotalTeamPlayers).NotEmpty().GreaterThanOrEqualTo(5).WithMessage("Teams must have a minimum of players.");
        RuleFor(x => x.MaximumTotalTeamPlayers).NotEmpty().LessThanOrEqualTo(30).WithMessage("Teams must have a minimum of players.");
        RuleFor(x => x.MaximumTotalTeamPlayers).NotEmpty().GreaterThanOrEqualTo(x => x.MinimumTotalTeamPlayers).WithMessage("Maximum number of players must be equal to or more than the minimum.");

    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<UpdateLeagueSettingsModel>.CreateWithOptions((UpdateLeagueSettingsModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}

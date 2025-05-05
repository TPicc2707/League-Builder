namespace League.Builder.Web.Server.Models.Season;

public class SeasonModel
{
    public Guid Id { get; set; }
    public int Year {  get; set; } = default!;
    public string Description { get; set; } = default!;
}

//Request Records
public record CreateSeasonRequest(int Year, string Description);
public record UpdateSeasonRequest(Guid Id, int Year, string Description);

//Response Records
public record GetSeasonsResponse(IEnumerable<SeasonModel> Seasons);
public record GetSeasonByIdResponse(SeasonModel Season);
public record GetSeasonByYearResponse(SeasonModel Season);
public record CreateSeasonResponse(Guid Id);
public record UpdateSeasonResponse(bool IsSuccess);
public record DeleteSeasonResponse(bool IsSuccess);
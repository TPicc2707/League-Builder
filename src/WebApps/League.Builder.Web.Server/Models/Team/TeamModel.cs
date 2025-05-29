namespace League.Builder.Web.Server.Models.Team;

public class TeamModel
{
    public Guid Id { get; set; }
    public Guid LeagueId { get; set; }
    public string TeamName { get; set; } = default!;
    public AddressModel TeamAddress { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public string Image { get; set; } = default!;
    public TeamStatus TeamStatus { get; set; } = default!;
}

public record CreateTeamModel(
    Guid LeagueId,
    string TeamName,
    AddressModel TeamAddress,
    string Description,
    string ImageFile);

public record UpdateTeamModel(
    Guid Id,
    Guid LeagueId,
    string TeamName,
    AddressModel TeamAddress,
    string Description,
    string ImageFile,
    int TeamStatus);

public record AddressModel(string FirstName, string LastName, string EmailAddress, string AddressLine, string Country, string State, string ZipCode);

public enum TeamStatus
{
    Shutdown = 1,
    OffSeason = 2,
    InSeason = 3,
    Available = 4
}

//Request Record
public record UpdateTeamRequest(UpdateTeamModel Team);
public record CreateTeamRequest(CreateTeamModel Team);

// Response Records
public record GetTeamsResponse(PaginatedResult<TeamModel> Teams);
public record GetTeamByIdResponse(TeamModel Team);
public record GetTeamsByNameResponse(IEnumerable<TeamModel> Teams);
public record GetTeamsBySportResponse(IEnumerable<TeamModel> Teams);
public record GetTeamsByStateResponse(IEnumerable<TeamModel> Teams);
public record GetTeamsByLeagueResponse(IEnumerable<TeamModel> Teams);
public record CreateTeamResponse(Guid Id);
public record UpdateTeamResponse(bool IsSuccess);
public record DeleteTeamResponse(bool IsSuccess);
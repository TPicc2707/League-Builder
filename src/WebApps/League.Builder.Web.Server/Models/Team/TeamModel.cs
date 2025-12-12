namespace League.Builder.Web.Server.Models.Team;

public class TeamModel
{
    public Guid Id { get; set; }
    public Guid LeagueId { get; set; }
    public string LeagueName { get; set; } = default!;
    public string Sport { get; set; } = default!;
    public string TeamName { get; set; } = default!;
    public AddressModel TeamAddress { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public string Image { get; set; } = default!;
    public TeamStatus TeamStatus { get; set; } = default!;
    public ManagerModel TeamManager { get; set; } = default!;
}

public record CreateTeamRecord(
    Guid LeagueId,
    string TeamName,
    AddressModel TeamAddress,
    string Description,
    string ImageFile,
    ManagerModel TeamManager);

public record UpdateTeamRecord(
    Guid Id,
    Guid LeagueId,
    string TeamName,
    AddressModel TeamAddress,
    string Description,
    string ImageFile,
    int TeamStatus,
    ManagerModel TeamManager);

public record AddressModel(string FirstName, string LastName, string EmailAddress, string AddressLine, string City, string Country, string State, string ZipCode);
public record ManagerModel(string FirstName, string LastName, string EmailAddress);

public enum TeamStatus
{
    Shutdown = 1,
    OffSeason = 2,
    InSeason = 3,
    Available = 4
}

//Request Record
public record UpdateTeamRequest(UpdateTeamRecord Team);
public record CreateTeamRequest(CreateTeamRecord Team);

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
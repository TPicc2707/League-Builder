namespace League.Builder.Web.Server.Models.League;

public class LeagueModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Sport { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public string Image { get; set; } = default!;
    public string OwnerFirstName { get; set; } = default!;
    public string OwnerLastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
}

// Request Records
public record CreateLeagueRequest(string Name, string Sport, string Description, string ImageFile, string OwnerFirstName, string OwnerLastName, string EmailAddress);
public record UpdateLeagueRequest(Guid Id, string Name, string Sport, string Description, string ImageFile, string OwnerFirstName, string OwnerLastName, string EmailAddress);

// Response Records
public record GetLeaguesResponse(IEnumerable<LeagueModel> Leagues);
public record GetLeagueByIdResponse(LeagueModel League);
public record GetLeaguesBySportResponse(IEnumerable<LeagueModel> Leagues);
public record GetLeaguesByNameResponse(IEnumerable<LeagueModel> Leagues);
public record CreateLeagueResponse(Guid Id);
public record UpdateLeagueResponse(bool IsSuccess);
public record DeleteLeagueResponse(bool IsSuccess);
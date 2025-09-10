namespace League.API.Models;
public class League
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Sport { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public string OwnerFirstName { get; set; } = default!;
    public string OwnerLastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public int TotalGamesPerSeason { get; set; } = default!;
    public int TotalPlayoffTeams { get; set; } = default!;
    public int MinimumTotalTeamPlayers { get; set; } = default!;
    public int MaximumTotalTeamPlayers { get; set; } = default!;
    public DateTime Created_DateTime { get; set; } = default!;
    public string Created_User { get; set; } = default!;
    public DateTime Modified_DateTime { get; set; } = default!;
    public string Modified_User { get; set;} = default!;    
}

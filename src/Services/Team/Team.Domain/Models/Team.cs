namespace Team.Domain.Models;
public class Team : Entity<TeamId>
{
    public LeagueId LeagueId { get; private set; } = default!;
    public TeamName TeamName { get; private set; } = default!;
    public Address TeamAddress { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string ImageFile { get; private set; } = default!;
    public string TeamColor { get; private set; } = default!;
    public TeamStatus TeamStatus { get; private set; } = default!;
    public Manager TeamManager { get; private set; } = default!;


    public static Team Create(TeamId id, LeagueId leagueId, TeamName teamName, Address teamAddress, string description, string imageFile, string teamColor, Manager teamManager)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(imageFile);

        var team = new Team
        {
            Id = id,
            LeagueId = leagueId,
            TeamName = teamName,
            TeamAddress = teamAddress,
            Description = description,
            ImageFile = imageFile,
            TeamColor = teamColor,
            TeamStatus = TeamStatus.OffSeason,
            TeamManager = teamManager
        };

        return team;
    }

    public void Update(LeagueId leagueId, TeamName teamName, Address teamAddress, string description, string imageFile, string teamColor, TeamStatus status, Manager teamManager)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(imageFile);

        LeagueId = leagueId;
        TeamName = teamName;
        TeamAddress = teamAddress;
        Description = description;
        ImageFile = imageFile;
        TeamColor = teamColor;
        TeamStatus = status;
        TeamManager = teamManager;
    }
}

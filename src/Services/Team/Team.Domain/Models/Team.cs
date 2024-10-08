namespace Team.Domain.Models;
public class Team : Entity<TeamId>
{
    public LeagueId LeagueId { get; private set; } = default!;
    public TeamName TeamName { get; private set; } = default!;
    public Address TeamAddress { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string ImageFile { get; private set; } = default!;
    public TeamStatus TeamStatus { get; private set; } = default!;


    public static Team Create(TeamId id, LeagueId leagueId, TeamName teamName, Address teamAddress, string description, string imageFile)
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
            TeamStatus = TeamStatus.OffSeason
        };

        return team;
    }

    public void Update(LeagueId leagueId, TeamName teamName, Address teamAddress, string description, string imageFile, TeamStatus status)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(imageFile);

        LeagueId = leagueId;
        TeamName = teamName;
        TeamAddress = teamAddress;
        Description = description;
        ImageFile = imageFile;
        TeamStatus = status;

    }
}

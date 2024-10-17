namespace Player.Domain.Models;
public class Team : Aggregate<TeamId>
{
    public string TeamName { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    public static Team Create(TeamId id, string teamName, string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(teamName);

        var team = new Team
        {
            Id = id,
            TeamName = teamName,
            Description = description
        };

        team.AddDomainEvent(new TeamCreatedEvent(team));

        return team;
    }

    public void Update(string teamName, string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(teamName);

        TeamName = teamName;
        Description = description;

        AddDomainEvent(new TeamUpdateEvent(this));
    }
}

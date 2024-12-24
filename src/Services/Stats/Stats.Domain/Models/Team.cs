namespace Stats.Domain.Models;

public class Team : Aggregate<TeamId>
{
    public string TeamName { get; private set; } = default!;

    public static Team Create(TeamId id, string teamName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(teamName);

        var team = new Team
        {
            Id = id,
            TeamName = teamName,
        };

        team.AddDomainEvent(new TeamCreatedEvent(team));

        return team;
    }

    public void Update(string teamName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(teamName);

        TeamName = teamName;

        AddDomainEvent(new TeamUpdateEvent(this));
    }
}

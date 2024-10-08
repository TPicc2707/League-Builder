namespace Team.Domain.Models;
public class League : Aggregate<LeagueId>
{
    public string Name { get; private set; } = default!;
    public Sport Sport { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    public static League Create(LeagueId id, string name, Sport sport, string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        var league = new League
        {
            Id = id,
            Name = name,
            Sport = sport,
            Description = description
        };

        league.AddDomainEvent(new LeagueCreatedEvent(league));

        return league;
    }

    public void Update(string name, Sport sport, string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
        Sport = sport;
        Description = description;

        AddDomainEvent(new LeagueUpdateEvent(this));
    }
}

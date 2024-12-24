namespace Stats.Domain.Models;

public class League : Aggregate<LeagueId>
{
    public string Name { get; set; }

    public static League Create(LeagueId id, string leagueName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(leagueName);

        var league = new League
        {
            Id = id,
            Name = leagueName,
        };

        league.AddDomainEvent(new LeagueCreatedEvent(league));

        return league;
    }

    public void Update(string leagueName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(leagueName);

        Name = leagueName;

        AddDomainEvent(new LeagueUpdateEvent(this));
    }
}

namespace Stats.Domain.Models;

public class Player : Aggregate<PlayerId>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public static Player Create(PlayerId id, string firstName, string lastName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);

        var player = new Player
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
        };

        player.AddDomainEvent(new PlayerCreatedEvent(player));

        return player;
    }

    public void Update(string firstName, string lastName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);

        FirstName = firstName;
        LastName = lastName;

        AddDomainEvent(new PlayerUpdateEvent(this));

    }
}
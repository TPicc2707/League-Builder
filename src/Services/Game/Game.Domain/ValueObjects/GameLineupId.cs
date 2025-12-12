namespace Game.Domain.ValueObjects;

public class GameLineupId
{
    public Guid Value { get; }
    private GameLineupId(Guid value) => Value = value;
    public static GameLineupId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new DomainException("GameLineupId cannot be empty.");

        return new GameLineupId(value);
    }
}

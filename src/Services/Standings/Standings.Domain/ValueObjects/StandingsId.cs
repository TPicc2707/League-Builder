namespace Standings.Domain.ValueObjects;

public class StandingsId
{
    public Guid Value { get; }
    private StandingsId(Guid value) => Value = value;
    public static StandingsId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new DomainException("StandingsId cannot be empty.");

        return new StandingsId(value);
    }
}

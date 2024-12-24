namespace Stats.Domain.ValueObjects;

public record FootballStatsId
{
    public Guid Value { get; }
    private FootballStatsId(Guid value) => Value = value;
    public static FootballStatsId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new DomainException("FootballStatsId cannot be empty.");

        return new FootballStatsId(value);
    }
}

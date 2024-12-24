namespace Stats.Domain.ValueObjects;

public record BaseballStatsId
{
    public Guid Value { get; }
    private BaseballStatsId(Guid value) => Value = value;
    public static BaseballStatsId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new DomainException("BaseballStatsId cannot be empty.");

        return new BaseballStatsId(value);
    }
}

namespace Stats.Domain.ValueObjects;

public record BasketballStatsId
{
    public Guid Value { get; }
    private BasketballStatsId(Guid value) => Value = value;
    public static BasketballStatsId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new DomainException("BasketballStatsId cannot be empty.");

        return new BasketballStatsId(value);
    }
}

namespace Stats.Domain.ValueObjects;

public record LeagueId
{
    public Guid Value { get; }
    private LeagueId(Guid value) => Value = value;
    public static LeagueId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new DomainException("LeagueId cannot be empty.");

        return new LeagueId(value);
    }
}

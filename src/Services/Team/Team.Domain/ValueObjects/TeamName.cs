namespace Team.Domain.ValueObjects;

public record TeamName
{
    private const int DefaultLength = 50;
    public string Value { get; }
    private TeamName(string value) => Value = value;

    public static TeamName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        //ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

        return new TeamName(value);
    }
}

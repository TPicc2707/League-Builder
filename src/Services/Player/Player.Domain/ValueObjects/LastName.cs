namespace Player.Domain.ValueObjects;

public record LastName
{
    private const int DefaultLength = 100;
    public string Value { get; }
    private LastName(string value) => Value = value;

    public static LastName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        //ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

        return new LastName(value);
    }
}

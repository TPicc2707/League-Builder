namespace Player.Domain.ValueObjects;

public record FirstName
{
    private const int DefaultLength = 100;
    public string Value { get; }
    private FirstName(string value) => Value = value;

    public static FirstName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        //ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

        return new FirstName(value);
    }
}

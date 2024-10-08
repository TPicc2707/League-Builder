namespace Team.Domain.ValueObjects;
public record Sport
{
    private const int DefaultLength = 50;
    public string Value { get; }
    private Sport(string value) => Value = value;

    public static Sport Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        //ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

        return new Sport(value);
    }
}

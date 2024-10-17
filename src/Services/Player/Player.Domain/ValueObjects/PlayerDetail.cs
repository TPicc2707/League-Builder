namespace Player.Domain.ValueObjects;

public record PlayerDetail
{
    public string? EmailAddress { get; } = default!;
    public string PhoneNumber { get; } = default!;
    public DateTime BirthDate { get; } = default!;
    public int Height { get; } = default!;
    public int Weight { get; } = default!;
    public string Position { get; } = default!;

    protected PlayerDetail()
    {

    }

    private PlayerDetail(string emailAddress, string phoneNumber, DateTime birthDate, int height, int weight, string position)
    {
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        Height = height;
        Weight = weight;
        Position = position;
    }

    public static PlayerDetail Of(string emailAddress, string phoneNumber, DateTime birthDate, int height, int weight, string position)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);

        return new PlayerDetail(emailAddress, phoneNumber, birthDate, height, weight, position);
    }
}

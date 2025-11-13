namespace Player.Domain.ValueObjects;

public record Address
{
    public string AddressLine { get; } = default!;
    public string City { get; } = default!;
    public string Country { get; } = default!;
    public string State { get; } = default!;
    public string ZipCode { get; } = default!;

    protected Address()
    {

    }

    private Address(string addressLine, string city, string country, string state, string zipCode)
    {
        AddressLine = addressLine;
        City = city;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    public static Address Of(string addressLine, string city, string country, string state, string zipCode)
    {
        
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);

        return new Address(addressLine, city, country, state, zipCode);
    }
}

namespace Team.Domain.ValueObjects;

public class Manager
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;

    protected Manager()
    {

    }

    private Manager(string firstName, string lastName, string emailAddress)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
    }

    public static Manager Of(string firstName, string lastName, string emailAddress)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);

        return new Manager(firstName, lastName, emailAddress);
    }
}

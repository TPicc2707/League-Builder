namespace BuildingBlocks.Messaging.Events;

public record PlayerCreationEvent : IntegrationEvent
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}

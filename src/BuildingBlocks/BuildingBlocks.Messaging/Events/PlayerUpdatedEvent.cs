namespace BuildingBlocks.Messaging.Events;

public record PlayerUpdatedEvent : IntegrationEvent
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}

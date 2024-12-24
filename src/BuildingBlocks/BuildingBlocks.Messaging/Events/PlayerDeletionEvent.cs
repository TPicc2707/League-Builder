namespace BuildingBlocks.Messaging.Events;

public record PlayerDeletionEvent : IntegrationEvent
{
    public Guid Id { get; set; }
}

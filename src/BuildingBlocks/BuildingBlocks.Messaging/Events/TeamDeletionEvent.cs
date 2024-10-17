namespace BuildingBlocks.Messaging.Events;

public record TeamDeletionEvent : IntegrationEvent
{
    public Guid Id { get; set; }
}

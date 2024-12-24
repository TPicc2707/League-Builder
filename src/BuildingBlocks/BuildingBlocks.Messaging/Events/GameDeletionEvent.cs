namespace BuildingBlocks.Messaging.Events;

public record GameDeletionEvent : IntegrationEvent
{
    public Guid Id { get; set; }
}

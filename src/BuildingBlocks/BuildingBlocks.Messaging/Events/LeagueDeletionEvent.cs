namespace BuildingBlocks.Messaging.Events;
public record LeagueDeletionEvent : IntegrationEvent
{
    public Guid Id { get; set; }
}

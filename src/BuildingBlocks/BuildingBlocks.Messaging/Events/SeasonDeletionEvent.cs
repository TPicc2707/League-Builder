namespace BuildingBlocks.Messaging.Events;

public record SeasonDeletionEvent : IntegrationEvent
{
    public Guid Id { get; set; }
}

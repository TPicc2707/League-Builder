namespace BuildingBlocks.Messaging.Events;

public record GameUpdatedEvent : IntegrationEvent
{
    public Guid Id { get; set; }
}

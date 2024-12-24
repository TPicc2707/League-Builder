namespace BuildingBlocks.Messaging.Events;

public record GameCreationEvent : IntegrationEvent
{
    public Guid Id { get; set; }
}
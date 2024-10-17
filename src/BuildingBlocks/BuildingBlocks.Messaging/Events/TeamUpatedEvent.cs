namespace BuildingBlocks.Messaging.Events;

public record TeamUpatedEvent : IntegrationEvent
{
    public Guid Id { get; set; }
    public string TeamName { get; set; } = default!;
    public string Description { get; set; } = default!;
}

namespace BuildingBlocks.Messaging.Events;

public record SeasonUpdatedEvent : IntegrationEvent
{
    public Guid Id { get; set; }
    public int Year { get; set; } = default!;
}

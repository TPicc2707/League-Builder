namespace BuildingBlocks.Messaging.Events;

public record SeasonCreationEvent : IntegrationEvent
{
    public Guid Id { get; set; }
    public int Year { get; set; } = default!;
}

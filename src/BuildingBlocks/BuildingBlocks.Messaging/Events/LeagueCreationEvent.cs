namespace BuildingBlocks.Messaging.Events;
public record LeagueCreationEvent : IntegrationEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Sport { get; set; } = default!;
    public string Description { get; set; } = default!;
}

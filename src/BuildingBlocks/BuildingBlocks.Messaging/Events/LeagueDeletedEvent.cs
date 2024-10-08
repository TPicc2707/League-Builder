namespace BuildingBlocks.Messaging.Events;
public record LeagueDeletedEvent : IntegrationEvent
{
    public Guid Id { get; set; }
}

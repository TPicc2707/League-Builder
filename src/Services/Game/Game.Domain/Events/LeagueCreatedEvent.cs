namespace Game.Domain.Events;

public record LeagueCreatedEvent(League league) : IDomainEvent;
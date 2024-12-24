namespace Stats.Domain.Events;

public record LeagueCreatedEvent(League league) : IDomainEvent;
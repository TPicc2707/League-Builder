namespace Stats.Domain.Events;

public record TeamCreatedEvent(Team team) : IDomainEvent;
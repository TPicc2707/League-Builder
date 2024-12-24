namespace Stats.Domain.Events;

public record TeamUpdateEvent(Team team) : IDomainEvent;

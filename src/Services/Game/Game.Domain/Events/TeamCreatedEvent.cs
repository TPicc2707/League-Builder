namespace Game.Domain.Events;

public record TeamCreatedEvent(Team team) : IDomainEvent;
namespace Game.Domain.Events;

public record TeamUpdateEvent(Team team) : IDomainEvent;

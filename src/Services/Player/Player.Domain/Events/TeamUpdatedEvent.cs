namespace Player.Domain.Events;
public record TeamUpdateEvent(Team team) : IDomainEvent;

namespace Player.Domain.Events;
public record TeamCreatedEvent(Team team) : IDomainEvent;


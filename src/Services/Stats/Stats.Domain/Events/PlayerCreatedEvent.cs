namespace Stats.Domain.Events;

public record PlayerCreatedEvent(Player player) : IDomainEvent;

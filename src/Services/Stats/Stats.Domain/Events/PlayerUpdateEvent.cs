namespace Stats.Domain.Events;

public record PlayerUpdateEvent(Player player) : IDomainEvent;

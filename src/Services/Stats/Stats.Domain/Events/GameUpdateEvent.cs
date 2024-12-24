namespace Stats.Domain.Events;

public record GameUpdateEvent(Game game) : IDomainEvent;

namespace Stats.Domain.Events;

public record GameCreatedEvent(Game game) : IDomainEvent;
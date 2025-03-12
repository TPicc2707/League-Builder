namespace Game.Domain.Events;

public record SeasonCreatedEvent(Season season) : IDomainEvent;
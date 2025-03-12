namespace Game.Domain.Events;

public record SeasonUpdateEvent(Season season) : IDomainEvent;
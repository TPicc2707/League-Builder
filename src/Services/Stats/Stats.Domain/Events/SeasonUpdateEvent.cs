namespace Stats.Domain.Events;

public record SeasonUpdateEvent(Season season) : IDomainEvent;
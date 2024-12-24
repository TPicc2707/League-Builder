namespace Stats.Domain.Events;

public record SeasonCreatedEvent(Season season) : IDomainEvent;
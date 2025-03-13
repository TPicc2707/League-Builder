namespace Standings.Domain.Events;

public record SeasonCreatedEvent(Season season) : IDomainEvent;
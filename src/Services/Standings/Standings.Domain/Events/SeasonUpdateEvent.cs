namespace Standings.Domain.Events;

public record SeasonUpdateEvent(Season season) : IDomainEvent;
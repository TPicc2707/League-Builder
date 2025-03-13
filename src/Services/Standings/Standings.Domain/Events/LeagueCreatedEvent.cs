namespace Standings.Domain.Events;

public record LeagueCreatedEvent(League league) : IDomainEvent;
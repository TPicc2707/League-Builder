namespace Standings.Domain.Events;

public record LeagueUpdateEvent(League league) : IDomainEvent;

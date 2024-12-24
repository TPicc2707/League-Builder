namespace Stats.Domain.Events;

public record LeagueUpdateEvent(League league) : IDomainEvent;

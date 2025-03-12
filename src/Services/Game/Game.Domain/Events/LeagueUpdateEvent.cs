namespace Game.Domain.Events;

public record LeagueUpdateEvent(League league) : IDomainEvent;

namespace Team.Domain.Events;
public record LeagueUpdateEvent(League league) : IDomainEvent;

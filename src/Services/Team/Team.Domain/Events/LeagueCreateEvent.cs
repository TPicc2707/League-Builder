namespace Team.Domain.Events;
public record LeagueCreateEvent(League league) : IDomainEvent;

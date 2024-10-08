namespace Team.Domain.Events;
public record LeagueCreatedEvent(League league) : IDomainEvent;

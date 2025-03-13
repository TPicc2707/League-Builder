namespace Standings.Domain.Events;

public record TeamCreatedEvent(Team team) : IDomainEvent;
namespace Standings.Domain.Events;

public record TeamUpdateEvent(Team team) : IDomainEvent;

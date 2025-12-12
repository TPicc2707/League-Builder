namespace Game.Application.GameLineup.Queries.AnyBaseballGameLineupByGameId;

public record AnyBaseballGameLineupByGameIdQuery(Guid GameId, Guid TeamId) : IQuery<AnyBaseballGameLineupByGameIdResult>;

public record AnyBaseballGameLineupByGameIdResult(bool IsLineupCreated);
namespace Game.Application.GameLineup.Queries.GetBaseballGameLineupByGameId;

public record GetBaseballGameLineupByGameIdQuery(Guid GameId, Guid TeamId) : IQuery<GetBaseballGameLineupByGameIdResult>;

public record GetBaseballGameLineupByGameIdResult(GameLineupDto GameLineup);

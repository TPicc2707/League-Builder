namespace Game.Application.GameLineup.Queries.GetBaseballGameLineupById;

public record GetBaseballGameLineupByIdQuery(Guid Id) : IQuery<GetBaseballGameLineupByIdResult>;

public record GetBaseballGameLineupByIdResult(GameLineupDto GameLineup);

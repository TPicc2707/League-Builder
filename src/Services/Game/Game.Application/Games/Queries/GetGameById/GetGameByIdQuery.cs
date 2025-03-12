namespace Game.Application.Games.Queries.GetGameById;

public record GetGameByIdQuery(Guid Id) : IQuery<GetGameByIdResult>;

public record GetGameByIdResult(GameDto Game);
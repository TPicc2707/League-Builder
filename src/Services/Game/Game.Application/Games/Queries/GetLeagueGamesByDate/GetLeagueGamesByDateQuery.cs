namespace Game.Application.Games.Queries.GetLeagueGamesByDate;

public record GetLeagueGamesByDateQuery(Guid LeagueId, DateTime Date) 
    : IQuery<GetLeagueGamesByDateResult>;

public record GetLeagueGamesByDateResult(IEnumerable<GameDto> Games);
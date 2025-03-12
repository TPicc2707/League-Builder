namespace Game.Application.Games.Queries.GetGamesByLeague;

public record GetGamesByLeagueQuery(Guid LeagueId)
    : IQuery<GetGamesByLeagueResult>;

public record GetGamesByLeagueResult(IEnumerable<GameDto> Games);
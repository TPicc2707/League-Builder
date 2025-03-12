namespace Game.Application.Games.Queries.GetGamesByTeam;

public record GetGamesByTeamQuery(Guid TeamId)
    : IQuery<GetGamesByTeamResult>;

public record GetGamesByTeamResult(IEnumerable<GameDto> Games);

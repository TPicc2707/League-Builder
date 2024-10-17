namespace Player.Application.Players.Queries.GetPlayersByTeam;

public record GetPlayersByTeamQuery(Guid TeamId)
    : IQuery<GetPlayersByTeamResult>;

public record GetPlayersByTeamResult(IEnumerable<PlayerDto> Players);
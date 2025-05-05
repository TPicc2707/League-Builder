namespace Game.Application.Extensions;

public static class GameExtensions
{
    public static IEnumerable<GameDto> ToGameDtoList(this IEnumerable<Domain.Models.Game> games, List<Team> teams)
    {
        return games.Select(game => new GameDto(Id: game.Id.Value,
            LeagueId: game.LeagueId.Value,
            WinningTeamId: game.WinningTeamId?.Value,
            SeasonId: game.SeasonId.Value,
            GameDetail: new GameDetailDto(
                game.GameDetail.AwayTeamScore,
                game.GameDetail.HomeTeamScore,
                game.GameDetail.StartTime,
                game.GameDetail.EndTime),
            GameStatus: game.GameStatus,
            AwayTeam: new TeamDto(
                game.AwayTeamId.Value,
                teams.FirstOrDefault(t => t.Id == game.AwayTeamId).TeamName),
            HomeTeam: new TeamDto(
                game.AwayTeamId.Value,
                teams.FirstOrDefault(t => t.Id == game.HomeTeamId).TeamName)));
    }

    public static GameDto ToSingleGameDto(this Domain.Models.Game game, Team awayTeam, Team homeTeam)
    {
        return new GameDto(
            Id: game.Id.Value,
            LeagueId: game.LeagueId.Value,
            WinningTeamId: game.WinningTeamId?.Value,
            SeasonId: game.SeasonId.Value,
            GameDetail: new GameDetailDto(
                game.GameDetail.AwayTeamScore,
                game.GameDetail.HomeTeamScore,
                game.GameDetail.StartTime,
                game.GameDetail.EndTime),
            GameStatus: game.GameStatus,
            AwayTeam: new TeamDto(
                game.AwayTeamId.Value,
                awayTeam.TeamName),
            HomeTeam: new TeamDto(
                game.HomeTeamId.Value,
                homeTeam.TeamName));
    }
}

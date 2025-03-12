namespace Game.Application.Extensions;

public static class GameExtensions
{
    public static IEnumerable<GameDto> ToGameDtoList(this IEnumerable<Domain.Models.Game> games)
    {
        return games.Select(game => new GameDto(Id: game.Id.Value,
            LeagueId: game.LeagueId.Value,
            AwayTeamId: game.AwayTeamId.Value,
            HomeTeamId: game.HomeTeamId.Value,
            WinningTeamId: game.WinningTeamId?.Value,
            SeasonId: game.SeasonId.Value,
            GameDetail: new GameDetailDto(
                game.GameDetail.AwayTeamScore,
                game.GameDetail.HomeTeamScore,
                game.GameDetail.StartTime,
                game.GameDetail.EndTime),
            GameStatus: game.GameStatus));
    }

    public static GameDto ToSingleGameDto(this Domain.Models.Game game)
    {
        return new GameDto(
            Id: game.Id.Value,
            LeagueId: game.LeagueId.Value,
            AwayTeamId: game.AwayTeamId.Value,
            HomeTeamId: game.HomeTeamId.Value,
            WinningTeamId: game.WinningTeamId?.Value,
            SeasonId: game.SeasonId.Value,
            GameDetail: new GameDetailDto(
                game.GameDetail.AwayTeamScore,
                game.GameDetail.HomeTeamScore,
                game.GameDetail.StartTime,
                game.GameDetail.EndTime),
            GameStatus: game.GameStatus);
    }
}

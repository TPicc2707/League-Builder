namespace Game.Domain.Models;

public class Game : Entity<GameId>
{
    public LeagueId LeagueId { get; private set; } = default!;
    public TeamId? AwayTeamId { get; private set; } = default!;
    public TeamId? HomeTeamId { get; private set; } = default!;
    public TeamId? WinningTeamId { get; private set; } = default!;
    public SeasonId SeasonId { get; private set; } = default!;
    public GameDetail GameDetail { get; private set; } = default!;
    public GameStatus GameStatus { get; private set; } = default;

    public static Game Create(GameId id, LeagueId leagueId, TeamId awayTeamId, TeamId homeTeamId, SeasonId seasonId, GameDetail gameDetail)
    {
        var game = new Game()
        {
            Id = id,
            LeagueId = leagueId,
            AwayTeamId = awayTeamId,
            HomeTeamId = homeTeamId,
            SeasonId = seasonId,
            GameDetail = gameDetail,
            GameStatus = GameStatus.NotStarted
        };

        return game;
    }

    public void Update(LeagueId leagueId, TeamId awayTeamId, TeamId homeTeamId, TeamId? winningTeamId, SeasonId seasonId, GameDetail gameDetail, GameStatus gameStatus)
    {
        LeagueId = leagueId;
        AwayTeamId = awayTeamId;
        HomeTeamId = homeTeamId;
        WinningTeamId = winningTeamId;
        SeasonId = seasonId;
        GameDetail = gameDetail;
        GameStatus = gameStatus;
    }
}

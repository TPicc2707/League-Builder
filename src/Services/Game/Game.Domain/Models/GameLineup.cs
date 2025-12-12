namespace Game.Domain.Models;

public class GameLineup : Entity<GameLineupId>
{
    public GameId GameId { get; private set; } = default!;
    public TeamId TeamId { get; private set; } = default!;
    public BaseballGameLineup BaseballLineup { get; private set; } = default!;

    public static GameLineup CreateBaseballLineup(GameLineupId id, GameId gameId, TeamId teamId, BaseballGameLineup baseballLineup)
    {
        var gameLineup = new GameLineup()
        {
            Id = id,
            GameId = gameId,
            TeamId = teamId,
            BaseballLineup = baseballLineup
        };
        return gameLineup;
    }

    public void UpdateBaseballLineup(GameId gameId, TeamId teamId, BaseballGameLineup baseballLineup)
    {
        GameId = gameId;
        TeamId = teamId;
        BaseballLineup = baseballLineup;
    }
}

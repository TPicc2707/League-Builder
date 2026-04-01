namespace League.Builder.Web.Server.Services;

public interface IGameSimulatorService
{
    GameSimulationState StartGame(GameLineupModel home, 
        GameLineupModel away, 
        IDictionary<Guid, BaseballHittingTotalsModel> seasonTotals,
        IDictionary<Guid, BaseballGameStatsModel> gameStats);
    GameSimulationState SimulateNextAtBat(
        GameSimulationState state,
        IDictionary<Guid, BaseballGameStatsModel> gameStats);

    void ChangePitcher(GameSimulationState state,
        Guid pitcherId,
        bool isHomeTeam);

    void PinchHitter(GameSimulationState state,
        Guid hitterId,
        bool isHomeTeam);

    Guid DetermineWinningPitcher(GameSimulationState state);

    Guid DetermineLosingPitcher(GameSimulationState state);
}

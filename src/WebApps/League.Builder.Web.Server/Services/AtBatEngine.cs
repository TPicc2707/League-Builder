namespace League.Builder.Web.Server.Services;

public class AtBatEngine
{
    private readonly Random _rng = new();
    private readonly Dictionary<Guid, PlayerProbabilities> _prob;

    public AtBatEngine(
        IDictionary<Guid, BaseballHittingTotalsModel> seasonTotals)
    {
        _prob = seasonTotals
            .ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.ToProbabilities(kvp.Key));
    }

    public AtBatResult GetOutcome(Guid playerId)
    {
        var p = _prob[playerId];
        double roll = _rng.NextDouble();

        if(roll < p.PStrikeout) return AtBatResult.Strikeout;
        roll -= p.PStrikeout;

        if (roll < p.POut) return AtBatResult.Out;
        roll -= p.POut;

        if (roll < p.PWalk) return AtBatResult.Walk;
        roll -= p.PWalk;

        if (roll < p.PSingle) return AtBatResult.Single;
        roll -= p.PSingle;

        if (roll < p.PDouble) return AtBatResult.Double;
        roll -= p.PDouble;

        if (roll < p.PTriple) return AtBatResult.Triple;

        return AtBatResult.HomeRun;
    }
}

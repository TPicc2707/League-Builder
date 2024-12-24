namespace Stats.Domain.ValueObjects;

public class FootballKickingStats
{
    public int FieldGoalsMade { get; set; }
    public int FieldGoalsAttempted { get; set; }
    public decimal FieldGoalPercentage { get; set; }
    public int ExtraPointsMade { get; set; }
    public int ExtraPointsAttempted { get;set; }
    public decimal ExtraPointPercentage { get; set; }
    public int Punts { get; set; }
    public int PuntingYards { get; set; }
    public int LongestPunt {  get; set; }

    protected FootballKickingStats()
    {

    }

    private FootballKickingStats(int fieldGoalsMade, int fieldGoalsAttempted, decimal fieldGoalPercentage, int extraPointsMade, int extraPointsAttempted, decimal extraPointPercentage, int punts, int puntingYards, int longestPunt)
    {
        FieldGoalsMade = fieldGoalsMade;
        FieldGoalsAttempted = fieldGoalsAttempted;
        FieldGoalPercentage = fieldGoalPercentage;
        ExtraPointsMade = extraPointsMade;
        ExtraPointsAttempted = extraPointsAttempted;
        ExtraPointPercentage = extraPointPercentage;
        Punts = punts;
        PuntingYards = puntingYards;
        LongestPunt = longestPunt;
    }

    public static FootballKickingStats Of(int fieldGoalsMade, int fieldGoalsAttempted, decimal fieldGoalPercentage, int extraPointsMade, int extraPointsAttempted, decimal extraPointPercentage, int punts, int puntingYards, int longestPunt)
    {
        return new FootballKickingStats(fieldGoalsMade, fieldGoalsAttempted, fieldGoalPercentage, extraPointsMade, extraPointsAttempted, extraPointPercentage, punts, puntingYards, longestPunt);
    }
}

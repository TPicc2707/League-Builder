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

    private FootballKickingStats(int fieldGoalsMade, int fieldGoalsAttempted, int extraPointsMade, int extraPointsAttempted, int punts, int puntingYards, int longestPunt)
    {
        FieldGoalsMade = fieldGoalsMade;
        FieldGoalsAttempted = fieldGoalsAttempted;
        if (fieldGoalsMade == 0 || fieldGoalsAttempted == 0)
            FieldGoalPercentage = 0.00M;
        else
            FieldGoalPercentage = fieldGoalsMade/ fieldGoalsAttempted;
        ExtraPointsMade = extraPointsMade;
        ExtraPointsAttempted = extraPointsAttempted;
        if (extraPointsMade == 0 || extraPointsAttempted == 0)
            ExtraPointPercentage = 0.00M;
        else
            ExtraPointPercentage = extraPointsMade / extraPointsAttempted;
        Punts = punts;
        PuntingYards = puntingYards;
        LongestPunt = longestPunt;
    }

    public static FootballKickingStats Of(int fieldGoalsMade, int fieldGoalsAttempted, int extraPointsMade, int extraPointsAttempted, int punts, int puntingYards, int longestPunt)
    {
        return new FootballKickingStats(fieldGoalsMade, fieldGoalsAttempted, extraPointsMade, extraPointsAttempted, punts, puntingYards, longestPunt);
    }
}

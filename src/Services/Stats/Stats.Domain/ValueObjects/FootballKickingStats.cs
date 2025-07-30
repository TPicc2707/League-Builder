namespace Stats.Domain.ValueObjects;

public class FootballKickingStats
{
    public int FieldGoalsMade { get; set; }
    public int FieldGoalsAttempted { get; set; }
    public int ExtraPointsMade { get; set; }
    public int ExtraPointsAttempted { get;set; }
    public int LongestKick { get; set; }
    public int Points { get; set; }
    public int Punts { get; set; }
    public int PuntingYards { get; set; }
    public int LongestPunt {  get; set; }

    protected FootballKickingStats()
    {

    }

    private FootballKickingStats(int fieldGoalsMade, int fieldGoalsAttempted, int extraPointsMade, int extraPointsAttempted, int longestKick, int points, int punts, int puntingYards, int longestPunt)
    {
        FieldGoalsMade = fieldGoalsMade;
        FieldGoalsAttempted = fieldGoalsAttempted;
        LongestKick = longestKick;
        Points = points;
        Punts = punts;
        PuntingYards = puntingYards;
        LongestPunt = longestPunt;
    }

    public static FootballKickingStats Of(int fieldGoalsMade, int fieldGoalsAttempted, int extraPointsMade, int extraPointsAttempted, int longestKick, int points, int punts, int puntingYards, int longestPunt)
    {
        return new FootballKickingStats(fieldGoalsMade, fieldGoalsAttempted, extraPointsMade, extraPointsAttempted, longestKick, points, punts, puntingYards, longestPunt);
    }
}

namespace Stats.Domain.ValueObjects;

public class FootballDefensiveStats
{
    public int Tackles { get; set; }
    public int Sacks { get; set; }
    public int TacklesForLoss { get; set; }
    public int PassesDefended { get; set; }
    public int DefensiveInterceptions { get; set; }
    public int DefensiveInterceptionYards { get; set; }
    public int LongestDefensiveInterceptionPlay {  get; set; }
    public int DefensiveTouchdowns { get; set; }
    public int ForcedFumbles { get; set; }
    public int RecoveredFumbles { get; set; }


    protected FootballDefensiveStats()
    {

    }

    private FootballDefensiveStats(int tackles, int sacks, int tacklesForLoss, int passesDefended, int defensiveInterceptions, int defensiveInterceptionYards, int longestDefensiveInterceptionPlay, int defensiveTouchdowns, int forcedFumbles, int recoveredFumbles)
    {
        Tackles = tackles;
        Sacks = sacks;
        TacklesForLoss = tacklesForLoss;
        PassesDefended = passesDefended;
        DefensiveInterceptions = defensiveInterceptions;
        DefensiveInterceptionYards = defensiveInterceptionYards;
        LongestDefensiveInterceptionPlay = longestDefensiveInterceptionPlay;
        DefensiveTouchdowns = defensiveTouchdowns;
        ForcedFumbles = forcedFumbles;
        RecoveredFumbles = recoveredFumbles;
    }

    public static FootballDefensiveStats Of(int tackles, int sacks, int tacklesForLoss, int passesDefended, int defensiveInterceptions, int defensiveInterceptionYards, int longestDefensiveInterceptionPlay, int defensiveTouchdowns, int forcedFumbles, int recoveredFumbles)
    {
        return new FootballDefensiveStats(tackles, sacks, tacklesForLoss, passesDefended, defensiveInterceptions, defensiveInterceptionYards, longestDefensiveInterceptionPlay, defensiveTouchdowns, forcedFumbles, recoveredFumbles);
    }
}

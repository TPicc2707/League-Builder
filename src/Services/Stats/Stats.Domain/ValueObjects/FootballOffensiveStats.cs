namespace Stats.Domain.ValueObjects;

public class FootballOffensiveStats
{
    public int PassingCompletions { get; set; }
    public int PassingAttempts { get; set; }
    public decimal PassingCompletionPercentage { get; set; }
    public int PassingYards { get; set; }
    public decimal PassingYardsPerPlay { get; set; }
    public int LongestPassingPlay {  get; set; }
    public int PassingTouchdowns { get; set; }
    public int PassingInterceptions { get; set; }
    public int Sacks { get; set; }
    public decimal PasserRating { get; set; }
    public int RushingAttempts { get; set; } 
    public int RushingYards { get; set; }
    public decimal RushingYardsAverage { get; set; }  
    public int LongestRushingPlay { get; set; } 
    public int RushingTouchdowns { get; set; }
    public int RushingFumbles { get; set; }
    public int RushingFumblesLost { get; set; }
    public int Receptions { get; set; }
    public int Targets { get; set; }    
    public int ReceivingYards { get; set; }
    public decimal ReceivingYardsPerPlay { get; set; }
    public int ReceivingTouchdowns { get; set; }
    public int ReceivingFumbles { get; set; }
    public int ReceivingFumblesLost { get; set; }
    public int YardsAfterCatch { get; set; }


    protected FootballOffensiveStats()
    {

    }
    
    private FootballOffensiveStats(int passingCompletions, int passingAttempts, int passingYards, int longestPassingPlay, int passingTouchdowns, int passingInterceptions, int sacks,
                                    int rushingAttempts, int rushingYards, int longestRushingPlay, int rushingTouchdowns, int rushingFumbles, int rushingFumblesLost, 
                                    int receptions, int targets, int receivingYards, int receivingTouchdowns, int receivingFumbles, int receivingFumblesLost, int yardsAfterCatch)
    {
        PassingCompletions = passingCompletions;
        PassingAttempts = passingAttempts;
        PassingCompletionPercentage = passingCompletions / passingAttempts;
        PassingYards = passingYards;
        PassingYardsPerPlay = passingYards / passingAttempts;
        LongestPassingPlay = longestPassingPlay;
        PassingTouchdowns = passingTouchdowns;
        PassingInterceptions = passingInterceptions;
        Sacks = sacks;
        PasserRating = (((((passingCompletions / passingAttempts) - (decimal)0.3) * 5) + (((passingYards / passingAttempts) - 3) * (decimal)0.25) + ((passingTouchdowns / passingAttempts) * 20) + ((decimal)2.375 - (passingInterceptions / passingAttempts)) / 6) * 100);
        RushingAttempts = rushingAttempts;
        RushingYards = rushingYards;
        RushingYardsAverage = rushingYards / rushingAttempts;
        LongestRushingPlay = longestRushingPlay;
        RushingTouchdowns = rushingTouchdowns;
        RushingFumbles = rushingFumbles;
        RushingFumblesLost = rushingFumblesLost;
        Receptions = receptions;
        Targets = targets;
        ReceivingYards = receivingYards;
        ReceivingYardsPerPlay = receivingYards / receptions;
        ReceivingTouchdowns = receivingTouchdowns;
        ReceivingFumbles = receivingFumbles;
        ReceivingFumblesLost = receivingFumblesLost;
        YardsAfterCatch = yardsAfterCatch;
    }

    public static FootballOffensiveStats Of(int passingCompletions, int passingAttempts, int passingYards, int longestPassingPlay, int passingTouchdowns, int passingInterceptions, int sacks,
                                    int rushingAttempts, int rushingYards, int longestRushingPlay, int rushingTouchdowns, int rushingFumbles, int rushingFumblesLost,
                                    int receptions, int targets, int receivingYards, int receivingTouchdowns, int receivingFumbles, int receivingFumblesLost, int yardsAfterCatch)
    {
        return new FootballOffensiveStats(passingCompletions, passingAttempts, passingYards, longestPassingPlay, passingTouchdowns, passingInterceptions, sacks,
                                    rushingAttempts, rushingYards, longestRushingPlay, rushingTouchdowns, rushingFumbles, rushingFumblesLost,
                                    receptions, targets, receivingYards, receivingTouchdowns, receivingFumbles, receivingFumblesLost, yardsAfterCatch);
    }
}

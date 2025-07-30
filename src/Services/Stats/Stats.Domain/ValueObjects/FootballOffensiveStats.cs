namespace Stats.Domain.ValueObjects;

public class FootballOffensiveStats
{
    public int PassingCompletions { get; set; }
    public int PassingAttempts { get; set; }
    public int PassingYards { get; set; }
    public int LongestPassingPlay {  get; set; }
    public int PassingTouchdowns { get; set; }
    public int PassingInterceptions { get; set; }
    public int Sacks { get; set; }
    public int RushingAttempts { get; set; } 
    public int RushingYards { get; set; }
    public int LongestRushingPlay { get; set; } 
    public int RushingTouchdowns { get; set; }
    public int RushingFumbles { get; set; }
    public int RushingFumblesLost { get; set; }
    public int Receptions { get; set; }
    public int Targets { get; set; }    
    public int ReceivingYards { get; set; }
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
        LongestPassingPlay = longestPassingPlay;
        PassingTouchdowns = passingTouchdowns;
        PassingInterceptions = passingInterceptions;
        Sacks = sacks;
        RushingAttempts = rushingAttempts;
        RushingYards = rushingYards;
        LongestRushingPlay = longestRushingPlay;
        RushingTouchdowns = rushingTouchdowns;
        RushingFumbles = rushingFumbles;
        RushingFumblesLost = rushingFumblesLost;
        Receptions = receptions;
        Targets = targets;
        ReceivingYards = receivingYards;
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

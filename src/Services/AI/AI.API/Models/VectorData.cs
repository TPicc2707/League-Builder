using Microsoft.Extensions.VectorData;

namespace AI.API.Models;
public record League
{
    [VectorStoreKey]
    public Guid Id { get; set; }
    [VectorStoreData]
    public string Name { get; set; }
    [VectorStoreData]
    public string Sport { get; set; }
    [VectorStoreData]
    public string Description { get; set; }
    [VectorStoreData]
    public string OwnerFirstName { get; set; }
    [VectorStoreData]
    public string OwnerLastName { get; set; }
    [VectorStoreData]
    public string EmailAddress { get; set; }
    [VectorStoreData]
    public int TotalGamesPerSeason { get; set; }
    [VectorStoreData]
    public int TotalPlayoffTeams { get; set; }
    [VectorStoreData]
    public int MinimumTotalTeamPlayers { get; set; }
    [VectorStoreData]
    public int MaximumTotalTeamPlayers { get; set; }
    // The 1536-dimensional array representing the semantic meaning of the Content
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> Vector { get; set; }

    public League()
    {

    }
}

public record Team
{
    [VectorStoreKey]
    public Guid Id { get; set; }
    [VectorStoreData]
    public string LeagueId { get; set; }
    [VectorStoreData]
    public string LeagueName { get; set; }
    [VectorStoreData]
    public string TeamName { get; set; }
    [VectorStoreData]
    public string Description { get; set; }
    [VectorStoreData]
    public string TeamColor { get; set; }
    [VectorStoreData]
    public string State { get; set; }
    [VectorStoreData]
    public string City { get; set; }
    [VectorStoreData]
    public string Country { get; set; }
    [VectorStoreData]
    public string ZipCode { get; set; }
    [VectorStoreData]
    public string ManagerFirstName { get; set; }
    [VectorStoreData]
    public string ManagerLastName { get; set; }
    [VectorStoreData]
    public string ManagerEmailAddress { get; set; }
    // The 1536-dimensional array representing the semantic meaning of the Content
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> Vector { get; set; }

    public Team()
    {

    }
}

public class Player
{
    [VectorStoreKey]
    public Guid Id { get; set; }
    [VectorStoreData]
    public string TeamId { get; set; }
    [VectorStoreData]
    public string TeamName { get; set; }
    [VectorStoreData]
    public string Sport { get; set; }
    [VectorStoreData]
    public string LeagueName { get; set; }
    [VectorStoreData]
    public string FirstName { get; set; }
    [VectorStoreData]
    public string LastName { get; set; }

    [VectorStoreData]
    public string State { get; set; }
    [VectorStoreData]
    public string City { get; set; }
    [VectorStoreData]
    public string Country { get; set; }
    [VectorStoreData]
    public string ZipCode { get; set; }
    [VectorStoreData]
    public string EmailAddress { get; set; }
    [VectorStoreData]
    public string PhoneNumber { get; set; }
    [VectorStoreData]
    public DateTime BirthDate { get; set; }
    [VectorStoreData]
    public int Height { get; set; }
    [VectorStoreData]
    public int Weight { get; set; }
    [VectorStoreData]
    public string Position { get; set; }
    [VectorStoreData]
    public int Number { get; set; }
    [VectorStoreData]
    public string Description { get; set; }
    // The 1536-dimensional array representing the semantic meaning of the Content
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> Vector { get; set; }


    public Player()
    {
        
    }
}

public class Season
{
    [VectorStoreKey]
    public Guid Id { get; set; }
    [VectorStoreData]
    public int Year { get; set; }
    [VectorStoreData]
    public string Description { get; set; }
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> Vector { get; set; }
    public Season()
    {

    }

}

public class Standings
{
    [VectorStoreKey]
    public Guid Id { get; set; }
    [VectorStoreData]
    public string LeagueId { get; set; }
    [VectorStoreData]
    public string LeagueName { get; set; }
    [VectorStoreData]
    public string Sport { get; set; }
    [VectorStoreData]
    public string SeasonId { get; set; }
    [VectorStoreData]
    public int SeasonYear { get; set; }
    [VectorStoreData]
    public string TeamId { get; set; }
    [VectorStoreData]
    public string TeamName { get; set; }
    [VectorStoreData]
    public string ManagerFirstName { get; set; }
    [VectorStoreData]
    public string ManagerLastName { get; set; }
    [VectorStoreData]
    public string State { get; set; }
    [VectorStoreData]
    public string City { get; set; }
    [VectorStoreData]
    public string Country { get; set; }
    [VectorStoreData]
    public string ZipCode { get; set; }
    [VectorStoreData]
    public int GamesPlayed { get; set; }
    [VectorStoreData]
    public int Wins { get; set; }
    [VectorStoreData]
    public int Losses { get; set; }
    [VectorStoreData]
    public int Ties { get; set; }
    [VectorStoreData]
    public bool PlayoffTeam { get; set; }
    [VectorStoreData]
    public bool Champion { get; set; }
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> Vector { get; set; }

    public Standings()
    {
        
    }
}

public class Game
{
    [VectorStoreKey]
    public Guid Id { get; set; }
    [VectorStoreData]
    public string LeagueId { get; set; }
    [VectorStoreData]
    public string LeagueName { get; set; }
    [VectorStoreData]
    public string Sport { get; set; }
    [VectorStoreData]
    public string WinningTeamId { get; set; }
    [VectorStoreData]
    public string WinningTeamName { get; set; }
    [VectorStoreData]
    public string AwayTeamId { get; set; }
    [VectorStoreData]
    public string AwayTeamName { get; set; }
    [VectorStoreData]
    public string HomeTeamId { get; set; }
    [VectorStoreData]
    public string HomeTeamName { get; set; }
    [VectorStoreData]
    public string GameStatus { get; set; }
    [VectorStoreData]
    public string SeasonId { get; set; }
    [VectorStoreData]
    public int SeasonYear { get; set; }
    [VectorStoreData]
    public int AwayTeamScore { get; set; }
    [VectorStoreData]
    public int HomeTeamScore { get; set; }
    [VectorStoreData]
    public DateTime StartTime { get; set; }
    [VectorStoreData]
    public DateTime? EndTime { get; set; }
    [VectorStoreData]
    public List<int>? AwayInningRuns { get; set; }
    [VectorStoreData]
    public List<int>? HomeInningRuns { get; set; }
    [VectorStoreData]
    public int? AwayTotalHits { get; set; }
    [VectorStoreData]
    public int? HomeTotalHits { get; set; }
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> Vector { get; set; }

    public Game()
    {
        
    }
}

public class BaseballStats
{
    [VectorStoreKey]
    public Guid Id { get; set; }
    [VectorStoreData]
    public string LeagueId { get; set; }
    [VectorStoreData]
    public string LeagueName { get; set; }
    [VectorStoreData]
    public string TeamId { get; set; }
    [VectorStoreData]
    public string TeamName { get; set; }
    [VectorStoreData]
    public string PlayerId { get; set; }
    [VectorStoreData]
    public string FullName { get; set; }
    [VectorStoreData]
    public string SeasonId { get; set; }
    [VectorStoreData]
    public int SeasonYear { get; set; }
    [VectorStoreData]
    public string GameId { get; set; }
    [VectorStoreData]
    public int AwayTeamScore { get; set; }
    [VectorStoreData]
    public int HomeTeamScore { get; set; }
    [VectorStoreData]
    public string AwayTeamId { get; set; }
    [VectorStoreData]
    public string AwayTeamName { get; set; }
    [VectorStoreData]
    public string HomeTeamId { get; set; }
    [VectorStoreData]
    public string HomeTeamName { get; set; }
    [VectorStoreData]
    public int AtBats { get; set; }
    [VectorStoreData]
    public int Hits { get; set; }
    [VectorStoreData]
    public int TotalBases { get; set; }
    [VectorStoreData]
    public int Runs { get; set; }
    [VectorStoreData]
    public int Doubles { get; set; }
    [VectorStoreData]
    public int Triples { get; set; }
    [VectorStoreData]
    public int HomeRuns { get; set; }
    [VectorStoreData]
    public int RunsBattedIn { get; set; }
    [VectorStoreData]
    public int StolenBases { get; set; }
    [VectorStoreData]
    public int CaughtStealing { get; set; }
    [VectorStoreData]
    public int Strikeouts { get; set; }
    [VectorStoreData]
    public int Walks { get; set; }
    [VectorStoreData]
    public int HitByPitch { get; set; }
    [VectorStoreData]
    public int SacrificeFly { get; set; }
    [VectorStoreData]
    public int Wins { get; set; }
    [VectorStoreData]
    public int Losses { get; set; }
    [VectorStoreData]
    public int PitchingRuns { get; set; }
    [VectorStoreData]
    public bool Start { get; set; }
    [VectorStoreData]
    public int Saves { get; set; }
    [VectorStoreData]
    public double Innings { get; set; }
    [VectorStoreData]
    public int HitsAllowed { get; set; }
    [VectorStoreData]
    public int WalksAllowed { get; set; }
    [VectorStoreData]
    public int PitchingStrikeouts { get; set; }
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> Vector { get; set; }

    public BaseballStats()
    {
        
    }
}

public class BasketballStats
{
    [VectorStoreKey]
    public Guid Id { get; set; }
    [VectorStoreData]
    public string LeagueId { get; set; }
    [VectorStoreData]
    public string LeagueName { get; set; }
    [VectorStoreData]
    public string TeamId { get; set; }
    [VectorStoreData]
    public string TeamName { get; set; }
    [VectorStoreData]
    public string PlayerId { get; set; }
    [VectorStoreData]
    public string FullName { get; set; }
    [VectorStoreData]
    public string SeasonId { get; set; }
    [VectorStoreData]
    public int SeasonYear { get; set; }
    [VectorStoreData]
    public string GameId { get; set; }
    [VectorStoreData]
    public int AwayTeamScore { get; set; }
    [VectorStoreData]
    public int HomeTeamScore { get; set; }
    [VectorStoreData]
    public string AwayTeamId { get; set; }
    [VectorStoreData]
    public string AwayTeamName { get; set; }
    [VectorStoreData]
    public string HomeTeamId { get; set; }
    [VectorStoreData]
    public string HomeTeamName { get; set; }
    [VectorStoreData]
    public bool Start { get; set; }
    [VectorStoreData]
    public int Minutes { get; set; }
    [VectorStoreData]
    public int Points { get; set; }
    [VectorStoreData]
    public int FieldGoalsMade { get; set; }
    [VectorStoreData]
    public int FieldGoalsAttempted { get; set; }
    [VectorStoreData]
    public int ThreePointersMade { get; set; }
    [VectorStoreData]
    public int ThreePointersAttempted { get; set; }
    [VectorStoreData]
    public int FreeThrowsMade { get; set; }
    [VectorStoreData]
    public int FreeThrowsAttempted { get; set; }
    [VectorStoreData]
    public int Rebounds { get; set; }
    [VectorStoreData]
    public int Assists { get; set; }
    [VectorStoreData]
    public int Steals { get; set; }
    [VectorStoreData]
    public int Blocks { get; set; }
    [VectorStoreData]
    public int Turnovers { get; set; }
    [VectorStoreData]
    public int Fouls { get; set; }
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> Vector { get; set; }

    public BasketballStats()
    {

    }
}

public class FootballStats
{
    [VectorStoreKey]
    public Guid Id { get; set; }
    [VectorStoreData]
    public string LeagueId { get; set; }
    [VectorStoreData]
    public string LeagueName { get; set; }
    [VectorStoreData]
    public string TeamId { get; set; }
    [VectorStoreData]
    public string TeamName { get; set; }
    [VectorStoreData]
    public string PlayerId { get; set; }
    [VectorStoreData]
    public string FullName { get; set; }
    [VectorStoreData]
    public string SeasonId { get; set; }
    [VectorStoreData]
    public int SeasonYear { get; set; }
    [VectorStoreData]
    public string GameId { get; set; }
    [VectorStoreData]
    public int AwayTeamScore { get; set; }
    [VectorStoreData]
    public int HomeTeamScore { get; set; }
    [VectorStoreData]
    public string AwayTeamId { get; set; }
    [VectorStoreData]
    public string AwayTeamName { get; set; }
    [VectorStoreData]
    public string HomeTeamId { get; set; }
    [VectorStoreData]
    public string HomeTeamName { get; set; }
    [VectorStoreData]
    public int PassingCompletions { get; set; }
    [VectorStoreData]
    public int PassingAttempts { get; set; }
    [VectorStoreData]
    public int PassingYards { get; set; }
    [VectorStoreData]
    public int LongestPassingPlay { get; set; }
    [VectorStoreData]
    public int PassingTouchdowns { get; set; }
    [VectorStoreData]
    public int PassingInterceptions { get; set; }
    [VectorStoreData]
    public int Sacks { get; set; }
    [VectorStoreData]
    public int RushingAttempts { get; set; }
    [VectorStoreData]
    public int RushingYards { get; set; }
    [VectorStoreData]
    public int LongestRushingPlay { get; set; }
    [VectorStoreData]
    public int RushingTouchdowns { get; set; }
    [VectorStoreData]
    public int RushingFumbles { get; set; }
    [VectorStoreData]
    public int RushingFumblesLost { get; set; }
    [VectorStoreData]
    public int Receptions { get; set; }
    [VectorStoreData]
    public int Targets { get; set; }
    [VectorStoreData]
    public int ReceivingYards { get; set; }
    [VectorStoreData]
    public int ReceivingTouchdowns { get; set; }
    [VectorStoreData]
    public int ReceivingFumbles { get; set; }
    [VectorStoreData]
    public int ReceivingFumblesLost { get; set; }
    [VectorStoreData]
    public int YardsAfterCatch { get; set; }
    [VectorStoreData]
    public int Tackles { get; set; }
    [VectorStoreData]
    public int DefensiveSacks { get; set; }
    [VectorStoreData]
    public int TacklesForLoss { get; set; }
    [VectorStoreData]
    public int PassesDefended { get; set; }
    [VectorStoreData]
    public int DefensiveInterceptions { get; set; }
    [VectorStoreData]
    public int DefensiveInterceptionYards { get; set; }
    [VectorStoreData]
    public int LongestDefensiveInterceptionPlay { get; set; }
    [VectorStoreData]
    public int DefensiveTouchdowns { get; set; }
    [VectorStoreData]
    public int ForcedFumbles { get; set; }
    [VectorStoreData]
    public int RecoveredFumbles { get; set; }
    [VectorStoreData]
    public int FieldGoalsMade { get; set; }
    [VectorStoreData]
    public int FieldGoalsAttempted { get; set; }
    [VectorStoreData]
    public int ExtraPointsMade { get; set; }
    [VectorStoreData]
    public int ExtraPointsAttempted { get; set; }
    [VectorStoreData]
    public int LongestKick { get; set; }
    [VectorStoreData]
    public int Points { get; set; }
    [VectorStoreData]
    public int Punts { get; set; }
    [VectorStoreData]
    public int PuntingYards { get; set; }
    [VectorStoreData]
    public int LongestPunt { get; set; }
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> Vector { get; set; }

    public FootballStats()
    {

    }
}
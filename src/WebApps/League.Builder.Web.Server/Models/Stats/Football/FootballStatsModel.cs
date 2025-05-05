namespace League.Builder.Web.Server.Models.Stats.Football;

public record FootballStatsModel(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    FootballOffensiveStatsModel OffensiveStats,
    FootballDefensiveStatsModel DefensiveStats,
    FootballKickingStatsModel KickingStats);

public record CreateFootballStatsModel(
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    CreateFootballOffensiveStatsModel OffensiveStats,
    CreateFootballDefensiveStatsModel DefensiveStats,
    CreateFootballKickingStatsModel KickingStats);

public record UpdateFootballStatsModel(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    UpdateFootballOffensiveStatsModel OffensiveStats,
    UpdateFootballDefensiveStatsModel DefensiveStats,
    UpdateFootballKickingStatsModel KickingStats);


public record FootballOffensiveStatsModel(
    int PassingCompletions,
    int PassingAttempts,
    decimal PassingCompletionPercentage,
    int PassingYards,
    decimal PassingYardsPerPlay,
    int LongestPassingPlay,
    int PassingTouchdowns,
    int PassingInterceptions,
    int Sacks,
    decimal PasserRating,
    int RushingAttempts,
    int RushingYards,
    decimal RushingYardsAverage,
    int LongestRushingPlay,
    int RushingTouchdowns,
    int RushingFumbles,
    int RushingFumblesLost,
    int Receptions,
    int Targets,
    int ReceivingYards,
    decimal ReceivingYardsPerPlay,
    int ReceivingTouchdowns,
    int ReceivingFumbles,
    int ReceivingFumblesLost,
    int YardsAfterCatch);

public record FootballDefensiveStatsModel(
    int Tackles,
    int Sacks,
    int TacklesForLoss,
    int PassesDefended,
    int DefensiveInterceptions,
    int DefensiveInterceptionYards,
    int LongestDefensiveInterceptionPlay,
    int DefensiveTouchdowns,
    int ForcedFumbles,
    int RecoveredFumbles);

public record FootballKickingStatsModel(
    int FieldGoalsMade,
    int FieldGoalsAttempted,
    decimal FieldGoalPercentage,
    int ExtraPointsMade,
    int ExtraPointsAttempted,
    decimal ExtraPointPercentage,
    int Punts,
    int PuntingYards,
    int LongestPunt);

public record CreateFootballOffensiveStatsModel(
    int PassingCompletions,
    int PassingAttempts,
    int PassingYards,
    int LongestPassingPlay,
    int PassingTouchdowns,
    int PassingInterceptions,
    int Sacks,
    int RushingAttempts,
    int RushingYards,
    int LongestRushingPlay,
    int RushingTouchdowns,
    int RushingFumbles,
    int RushingFumblesLost,
    int Receptions,
    int Targets,
    int ReceivingYards,
    int ReceivingTouchdowns,
    int ReceivingFumbles,
    int ReceivingFumblesLost,
    int YardsAfterCatch);

public record CreateFootballDefensiveStatsModel(
    int Tackles,
    int Sacks,
    int TacklesForLoss,
    int PassesDefended,
    int DefensiveInterceptions,
    int DefensiveInterceptionYards,
    int LongestDefensiveInterceptionPlay,
    int DefensiveTouchdowns,
    int ForcedFumbles,
    int RecoveredFumbles);

public record CreateFootballKickingStatsModel(
    int FieldGoalsMade,
    int FieldGoalsAttempted,
    int ExtraPointsMade,
    int ExtraPointsAttempted,
    int Punts,
    int PuntingYards,
    int LongestPunt);

public record UpdateFootballOffensiveStatsModel(
    int PassingCompletions,
    int PassingAttempts,
    int PassingYards,
    int LongestPassingPlay,
    int PassingTouchdowns,
    int PassingInterceptions,
    int Sacks,
    int RushingAttempts,
    int RushingYards,
    int LongestRushingPlay,
    int RushingTouchdowns,
    int RushingFumbles,
    int RushingFumblesLost,
    int Receptions,
    int Targets,
    int ReceivingYards,
    int ReceivingTouchdowns,
    int ReceivingFumbles,
    int ReceivingFumblesLost,
    int YardsAfterCatch);

public record UpdateFootballDefensiveStatsModel(
    int Tackles,
    int Sacks,
    int TacklesForLoss,
    int PassesDefended,
    int DefensiveInterceptions,
    int DefensiveInterceptionYards,
    int LongestDefensiveInterceptionPlay,
    int DefensiveTouchdowns,
    int ForcedFumbles,
    int RecoveredFumbles);

public record UpdateFootballKickingStatsModel(
    int FieldGoalsMade,
    int FieldGoalsAttempted,
    int ExtraPointsMade,
    int ExtraPointsAttempted,
    int Punts,
    int PuntingYards,
    int LongestPunt);

//Request Records
public record CreateFootballStatsRequest(CreateFootballStatsModel FootballStats);
public record UpdateFootballStatsRequest(UpdateFootballStatsModel FootballStats);

//Response Records
public record GetFootballStatsResponse(PaginatedResult<FootballStatsModel> FootballStats);
public record GetFootballStatByIdResponse(FootballStatsModel FootballStats);
public record GetFootballStatsByLeagueResponse(IEnumerable<FootballStatsModel> FootballStats);
public record GetFootballStatsByTeamResponse(IEnumerable<FootballStatsModel> FootballStats);
public record GetFootballStatsByPlayerResponse(IEnumerable<FootballStatsModel> FootballStats);
public record GetLeagueFootballStatsBySeasonResponse(IEnumerable<FootballStatsModel> FootballStats);
public record GetPlayerFootballStatByGameResponse(FootballStatsModel FootballStats);
public record GetPlayerFootballStatsBySeasonResponse(IEnumerable<FootballStatsModel> FootballStats);
public record GetTeamFootballStatsByGameResponse(IEnumerable<FootballStatsModel> FootballStats);
public record GetTeamFootballStatsBySeasonResponse(IEnumerable<FootballStatsModel> FootballStats);
public record CreateFootballStatsResponse(Guid Id);
public record UpdateFootballStatsResponse(bool IsSuccess);
public record DeleteFootballStatsResponse(bool IsSuccess);
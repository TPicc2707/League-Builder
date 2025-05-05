﻿namespace League.Builder.Web.Server.Models.Standings;

public record StandingsModel(
    Guid Id,
    Guid LeagueId,
    Guid SeasonId,
    StandingsDetailModel StandingsDetail,
    StandingsStatus StandingsStatus,
    TeamDetailModel Team);

public record CreateStandingsModel(
    Guid LeagueId,
    Guid SeasonId,
    StandingsDetailModel StandingsDetail,
    TeamDetailModel Team
);

public record UpdateStandingsModel(
    Guid Id,
    Guid LeagueId,
    Guid SeasonId,
    StandingsDetailModel StandingsDetail,
    int StandingStatus,
    TeamDetailModel Team
);


public record StandingsDetailModel(int GamesPlayed, int Wins, int Losses, int Ties);

public record TeamDetailModel(Guid Id, string TeamName);

public enum StandingsStatus
{
    NotStarted = 1,
    InProgress = 2,
    Finished = 3
}


// Request Record
public record CreateStandingsRequest(CreateStandingsModel Standings);
public record UpdateStandingsRequest(UpdateStandingsModel Standings);

// Response Record
public record GetStandingsResponse(PaginatedResult<StandingsModel> Standings);
public record GetStandingsByIdResponse(StandingsModel Standing);
public record GetStandingsByLeagueResponse(IEnumerable<StandingsModel> Standings);
public record GetStandingsByTeamResponse(IEnumerable<StandingsModel> Standings);
public record CreateStandingsResponse(Guid Id);
public record UpdateStandingsResponse(bool IsSuccess);
public record DeleteStandingsResponse(bool IsSuccess);
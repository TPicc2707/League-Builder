﻿namespace League.Builder.Web.Services;

public interface ILeagueService
{
    [Get("/league-service/leagues?pageNumber={pageNumber}&pageSize={pageSize}")]
    Task<GetLeaguesResponse> GetLeagues(int? pageNumber = 1, int? pageSize = 10);
    [Get("/league-service/leagues/{id}")]
    Task<GetLeagueByIdResponse> GetLeague(Guid id);
    [Get("/league-service/leagues/sport/{sport}")]
    Task<GetLeaguesBySportResponse> GetLeaguesBySport(string sport);
    [Post("/league-service/leagues")]
    Task<CreateLeagueResponse> CreateLeague(CreateLeagueRequest request);
    [Put("/league-service/leagues")]
    Task<UpdateLeagueResponse> UpdateLeague(UpdateLeagueRequest request);
    [Delete("/league-service/leagues/{id}")]
    Task<DeleteLeagueResponse> DeleteLeague(Guid id);
}

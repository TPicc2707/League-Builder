namespace League.Builder.Web.Server.Services;

public interface ILeagueService
{
    [Get("/league-service/leagues?pageNumber={pageNumber}&pageSize={pageSize}")]
    Task<GetLeaguesResponse> GetLeagues(int? pageNumber = 1, int? pageSize = 10);
    [Get("/league-service/leagues/{id}")]
    Task<GetLeagueByIdResponse> GetLeague(Guid id);
    [Get("/league-service/leagues/sport/{sport}")]
    Task<GetLeaguesBySportResponse> GetLeaguesBySport(string sport);
    [Get("/league-service/leagues/name/{name}")]
    Task<GetLeaguesByNameResponse> GetLeaguesByName(string name);
    [Get("/league-service/healthz")]
    Task<string> GetLeagueHealth();
    [Post("/league-service/leagues")]
    Task<CreateLeagueResponse> CreateLeague(CreateLeagueRequest request);
    [Put("/league-service/leagues")]
    Task<UpdateLeagueResponse> UpdateLeague(UpdateLeagueRequest request);
    [Put("/league-service/leagues/settings")]
    Task<UpdateLeagueResponse> UpdateLeagueSettings(UpdateLeagueSettingsRequest request);
    [Delete("/league-service/leagues/{id}")]
    Task<DeleteLeagueResponse> DeleteLeague(Guid id);
}

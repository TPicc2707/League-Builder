namespace League.Builder.Web.Services;

public interface IStandingsService
{
    [Get("/standings-service/standings?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetStandingsResponse> GetStandings(int? pageIndex = 0, int? pageSize = 4);
    [Get("/standings-service/standings/{id}")]
    Task<GetStandingsByIdResponse> GetStanding(Guid id);
    [Get("/standings-service/standings/league/{leagueId}")]
    Task<GetStandingsByLeagueResponse> GetStandingsByLeague(Guid leagueId);
    [Get("/standings-service/standings/team/{teamId}")]
    Task<GetStandingsByTeamResponse> GetStandingsByTeam(Guid teamId);
    [Post("/standings-service/standings")]
    Task<CreateStandingsResponse> CreateStandings(CreateStandingsRequest standings);
    [Put("/standings-service/standings")]
    Task<UpdateStandingsResponse> UpdateStandings(UpdateStandingsRequest standings);
    [Delete("/standings-service/standings/{id}")]
    Task<DeleteStandingsResponse> DeleteStandings(Guid id);
}

namespace League.Builder.Web.Services;

public interface ITeamService
{
    [Get("/team-service/teams?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetTeamsResponse> GetTeams(int? pageIndex = 0, int? pageSize = 4);
    [Get("/team-service/teams/{id}")]
    Task<GetTeamByIdResponse> GetTeamById(Guid id);
    [Get("/team-service/teams/league/{leagueId}")]
    Task<GetTeamsByLeagueResponse> GetTeamsByLeague(Guid leagueId);
    [Get("/team-service/teams/name/{name}")]
    Task<GetTeamsByNameResponse> GetTeamsByName(string name);
    [Get("/team-service/teams/sport/{sport}")]
    Task<GetTeamsBySportResponse> GetTeamsBySport(string sport);
    [Get("/team-service/teams/state/{state}")]
    Task<GetTeamsByStateResponse> GetTeamsByState(string state);
    [Post("/team-service/teams")]
    Task<CreateTeamResponse> CreateTeam(CreateTeamRequest team);
    [Put("/team-service/teams")]
    Task<UpdateTeamResponse> UpdateTeam(UpdateTeamRequest team);
    [Delete("/team-service/teams/{id}")]
    Task<DeleteTeamResponse> DeleteTeam(Guid id);
}

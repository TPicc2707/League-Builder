namespace League.Builder.Web.Services;

public interface IPlayerService
{
    [Get("/player-service/players?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetPlayersResponse> GetPlayers(int? pageIndex = 0, int? pageSize = 4);
    [Get("/player-service/players/{id}")]
    Task<GetPlayerByIdResponse> GetPlayerById(Guid id);
    [Get("/player-service/players/team/{teamId}")]
    Task<GetPlayersByTeamResponse> GetPlayersByTeam(Guid teamId);
    [Get("/player-service/players/firstname/{firstName}")]
    Task<GetPlayersByFirstNameResponse> GetPlayersByFirstName(string firstName);
    [Get("/player-service/players/lastname/{lastName}")]
    Task<GetPlayersByLastNameResponse> GetPlayersByLastName(string lastName);
    [Get("/player-service/players/position/{position}")]
    Task<GetPlayersByPositionResponse> GetPlayersByPosition(string position);
    [Get("/player-service/players/state/{state}")]
    Task<GetPlayersByStateResponse> GetPlayersByState(string state);
    [Get("/player-service/players/by-birthdate/{birthDate}")]
    Task<GetPlayersByBirthDateResponse> GetPlayersByBirthDate(string birthDate);
    [Get("/player-service/players/before-birthdate/{birthDate}")]
    Task<GetPlayersBeforeBirthDateResponse> GetPlayersBeforeBirthDate(string birthDate);
    [Get("/player-service/players/after-birthdate/{birthDate}")]
    Task<GetPlayersAfterBirthDateResponse> GetPlayersAfterBirthDate(string birthDate);
    [Post("/player-service/players")]
    Task<CreatePlayerResponse> CreatePlayer(CreatePlayerRequest player);
    [Put("/player-service/players")]
    Task<UpdatePlayerResponse> UpdatePlayer(UpdatePlayerRequest player);
    [Delete("/player-service/players/{id}")]
    Task<DeletePlayerResponse> DeletePlayer(Guid id);


}

namespace League.Builder.Web.Server.Services.Cache;

public interface IPlayerLocalCacheService
{
    Task<GetPlayersResponse> GetPlayersCache();
    Task<GetPlayerByIdResponse> GetPlayerByIdCache(string id);
    Task<GetPlayersByTeamResponse> GetPlayersByTeamCache(string teamId);
    Task<GetPlayersByFirstNameResponse> GetPlayersByFirstNameCache();
    Task<GetPlayersByLastNameResponse> GetPlayersByLastNameCache();
    Task<GetPlayersByPositionResponse> GetPlayersByPositionCache();
    Task<GetPlayersByBirthDateResponse> GetPlayersByBirthDateCache();
    Task<GetPlayersBeforeBirthDateResponse> GetPlayersBeforeBirthDateCache();
    Task<GetPlayersAfterBirthDateResponse> GetPlayersAfterBirthDateCache();
    Task SetPlayersCache(GetPlayersResponse playersResponse);
    Task SetPlayerByIdCache(GetPlayerByIdResponse playerByIdResponse, string id);
    Task SetPlayersByTeamCache(string teamId, GetPlayersByTeamResponse playersByTeamResponse);
    Task SetPlayersByFirstNameCache(GetPlayersByFirstNameResponse playersByFirstNameResponse);
    Task SetPlayersByLastNameCache(GetPlayersByLastNameResponse playersByLastNameResponse);
    Task SetPlayersByPositionCache(GetPlayersByPositionResponse playersByPositionResponse);
    Task SetPlayersByBirthDateCache(GetPlayersByBirthDateResponse playersByBirthDateResponse);
    Task SetPlayersBeforeBirthDateCache(GetPlayersBeforeBirthDateResponse playersBeforeBirthDateResponse);
    Task SetPlayersAfterBirthDateCache(GetPlayersAfterBirthDateResponse playersAfterBirthDateResponse);
    Task DeletePlayersCache();
    Task DeletePlayersByTeamCache(string id);
    Task DeletePlayersByFirstNameCache();
    Task DeletePlayersByLastNameCache();
    Task DeletePlayersByPositionCache();
    Task DeletePlayersByBirthDateCache();
    Task DeletePlayersBeforeBirthDateCache();
    Task DeletePlayersAfterBirthDateCache();

}

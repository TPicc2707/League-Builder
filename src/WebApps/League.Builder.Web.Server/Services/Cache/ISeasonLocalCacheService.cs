namespace League.Builder.Web.Server.Services.Cache;

public interface ISeasonLocalCacheService
{
    Task<GetSeasonsResponse> GetSeasonsCache();
    Task<GetSeasonByIdResponse> GetSeasonByIdCache(string id);
    Task<GetSeasonByYearResponse> GetSeasonByYearCache(int year);
    Task SetSeasonsCache(GetSeasonsResponse seasonsResponse);
    Task SetSeasonByIdCache(string id, GetSeasonByIdResponse seasonByIdResponse);
    Task SetSeasonByYearCache(int year, GetSeasonByYearResponse seasonByYearResponse);
    Task DeleteSeasonsCache();
    Task DeleteSeasonByIdCache(string id);
    Task DeleteSeasonByYearCache(int year);
}

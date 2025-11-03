using Blazored.LocalStorage;

namespace League.Builder.Web.Server.Services.Cache;

public class SeasonLocalCacheService : ISeasonLocalCacheService
{
    private readonly ILocalStorageService _localStorage;

    public SeasonLocalCacheService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }

    public async Task<GetSeasonsResponse> GetSeasonsCache()
    {
        return await _localStorage.GetItemAsync<GetSeasonsResponse>("Seasons");
    }

    public async Task<GetSeasonByIdResponse> GetSeasonByIdCache(string id)
    {
        return await _localStorage.GetItemAsync<GetSeasonByIdResponse>($"Season: {id}");
    }

    public async Task<GetSeasonByYearResponse> GetSeasonByYearCache(int year)
    {
        return await _localStorage.GetItemAsync<GetSeasonByYearResponse>($"SeasonByYear: {year}");
    }

    public async Task SetSeasonsCache(GetSeasonsResponse seasonsResponse)
    {
        await _localStorage.SetItemAsync("Seasons", seasonsResponse);
    }

    public async Task SetSeasonByIdCache(string id, GetSeasonByIdResponse seasonByIdResponse)
    {
        await _localStorage.SetItemAsync($"Season: {id}", seasonByIdResponse);
    }

    public async Task SetSeasonByYearCache(int year, GetSeasonByYearResponse seasonByYearResponse)
    {
        await _localStorage.SetItemAsync($"SeasonByYear: {year}", seasonByYearResponse);
    }

    public async Task DeleteSeasonsCache()
    {
        await _localStorage.RemoveItemAsync("Seasons");
    }

    public async Task DeleteSeasonByIdCache(string id)
    {
        await _localStorage.RemoveItemAsync($"Season: {id}");
    }

    public async Task DeleteSeasonByYearCache(int year)
    {
        await _localStorage.RemoveItemAsync($"SeasonByYear: {year}");
    }
}

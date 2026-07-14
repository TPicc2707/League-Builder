using System.Text.Json;

namespace AI.API.Services;

public class KeycloakTokenService
{
    private readonly HttpClient _http;

    public KeycloakTokenService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("Keycloak");
    }

    public async Task<string> GetTokenAsync()
    {
        var form = new Dictionary<string, string>
        {
            ["grant_type"] = "client_credentials",
            ["client_id"] = "ai-api-client",
            ["client_secret"] = "pu4kqY9jko9eX8FRAGtqMpg5aNyqB7Te"
        };

        var response = await _http.PostAsync(
            "realms/LeagueRealm/protocol/openid-connect/token",
            new FormUrlEncodedContent(form));

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var token = JsonDocument.Parse(json)
                                .RootElement
                                .GetProperty("access_token")
                                .GetString();

        return token!;
    }
}

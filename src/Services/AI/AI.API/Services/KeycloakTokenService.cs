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
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var isLocal = env == "Development" || env == "Local";

        var clientSecret = isLocal
            ? "pu4kqY9jko9eX8FRAGtqMpg5aNyqB7Te"
            : "jk3eCq14OYBd0M6rMy6tLQkMRCw42D6l";


        var form = new Dictionary<string, string>
        {
            ["grant_type"] = "client_credentials",
            ["client_id"] = "ai-api-client",
            ["client_secret"] = clientSecret
        };

        var response = await _http.PostAsync(
            "realms/LeagueRealm/protocol/openid-connect/token",
            new FormUrlEncodedContent(form));

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"TOKEN RESPONSE: " + json);
        var token = JsonDocument.Parse(json)
                                .RootElement
                                .GetProperty("access_token")
                                .GetString();

        return token!;
    }
}

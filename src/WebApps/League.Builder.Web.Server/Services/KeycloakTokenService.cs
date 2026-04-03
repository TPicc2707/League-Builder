using League.Builder.Web.Server.Models;
using System.Text.Json;

namespace League.Builder.Web.Server.Services;

public class KeycloakTokenService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContext;

    public KeycloakTokenService(IConfiguration configuration, IHttpClientFactory httpFactory, IHttpContextAccessor httpContext)
    {
        _configuration = configuration;
        _httpClient = httpFactory.CreateClient();
        _httpContext = httpContext;
    }

    public async Task<TokenResponse> RefreshTokensAsync(string refreshToken)
    {
        var clientId = _configuration["KeycloakClient"];
        var clientSecret = _configuration["KeycloakSecret"];
        var authority = _configuration["KeycloakAuthority"];

        var parameters = new Dictionary<string, string>
        {
            { "client_id",  clientId},
            { "client_secret", clientSecret },
            { "grant_type", "refresh_token" },
            { "refresh_token", refreshToken },
            { "scope", "openid profile email offline_access" }
        };

        var response = await _httpClient.PostAsync($"{authority}/protocol/openid-connect/token",
            new FormUrlEncodedContent(parameters));

        if (!response.IsSuccessStatusCode)
            return null;

        var json = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(json);

        // Extract access token expiration from JWT
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(tokenResponse.AccessToken);

        var expUnix = long.Parse(jwt.Claims.First(c => c.Type == "exp").Value);
        var expUtc = DateTimeOffset.FromUnixTimeSeconds(expUnix).UtcDateTime;

        tokenResponse.ExpiresAt = expUtc.ToString("o");

        Console.WriteLine($"Access token expires at: {tokenResponse.ExpiresAt}");

        return tokenResponse;
    }

    public bool ShouldForceLogout()
    {
        return _httpContext.HttpContext.Items.TryGetValue("ForceLogout", out var flag) == true && flag is true;
    }
}

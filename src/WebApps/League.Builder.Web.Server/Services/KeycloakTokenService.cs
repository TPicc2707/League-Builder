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

    public async Task<bool> SignUpAsync(RegisterModel model)
    {
        try
        {
            var authority = _configuration["KeycloakAdmin:Authority"];
            var realm = _configuration["KeycloakAdmin:Realm"];

            var token = await GetAdminTokenAsync();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var user = new
            {
                username = $"{model.FirstName.ToLower()}-{model.LastName.ToLower()}",
                email = model.Email,
                firstName = model.FirstName,
                lastName = model.LastName,
                enabled = false,
            };
            var response = await client.PostAsJsonAsync(
                $"{authority}/admin/realms/{realm}/users",
                user
            );

            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("FAILED: " + response.StatusCode);
                Console.WriteLine(body);
                return false;
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task<string> GetAdminTokenAsync()
    {
        var client = new HttpClient();
        var clientId = _configuration["KeycloakAdmin:ClientId"];
        var clientSecret = _configuration["KeycloakAdmin:ClientSecret"];
        var authority = _configuration["KeycloakAdmin:Authority"];
        var realm = _configuration["KeycloakAdmin:Realm"];

        var values = new Dictionary<string, string>
        {
            { "client_id", clientId },
            { "client_secret", clientSecret },
            { "grant_type", "client_credentials" }
        };

        var content = new FormUrlEncodedContent(values);

        var response = await client.PostAsync($"{authority}/realms/{realm}/protocol/openid-connect/token",
            content
        );

        var json = await response.Content.ReadFromJsonAsync<TokenResponse>();
        return json.AccessToken;
    }
}

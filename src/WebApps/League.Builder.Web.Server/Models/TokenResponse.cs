using System.Text.Json.Serialization;

namespace League.Builder.Web.Server.Models;

public class TokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
    [JsonPropertyName("expires_in")]
    public int? ExpiresIn { get; set; }

    public string ExpiresAt { get; set; }

    public void ComputeExpiresAt()
    {
        if (ExpiresIn.HasValue)
        {
            ExpiresAt = DateTime.UtcNow.AddSeconds(ExpiresIn.Value).ToString("o");
            return;
        }

        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(AccessToken);
        var expUnix = long.Parse(jwt.Claims.First(c => c.Type == "exp").Value);

        ExpiresAt = DateTimeOffset.FromUnixTimeSeconds(expUnix).UtcDateTime.ToString("o");
    }
}

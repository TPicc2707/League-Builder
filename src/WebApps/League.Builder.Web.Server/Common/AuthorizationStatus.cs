namespace League.Builder.Web.Server.Common;

public static class AuthorizationStatus
{

    public static bool TokenIsExpiringSoon(string expiresAt)
    {
        if (string.IsNullOrEmpty(expiresAt))
            return true; // force refresh if missing

        var expiry = DateTime.Parse(expiresAt).ToUniversalTime();
        var now = DateTime.UtcNow;

        return expiry <= now.AddSeconds(60);  //refresh with 1 minute left
    }

    public static async Task<bool> IsRefreshUserToken(IHttpContextAccessor httpContextAccessor)
    {
        var httpContext = httpContextAccessor.HttpContext;
        var accessToken = await httpContext.GetTokenAsync("access_token");

        if (accessToken is null) return false;

        var securityToken = ConvertJwtStringToJwtSecurityToken(accessToken);
        var expiry = securityToken.Claims.Where(c => c.Type.Equals("exp")).FirstOrDefault();

        if (expiry is not null)
        {
            var dateTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expiry.Value)).DateTime.ToLocalTime();
            int value = DateTime.Compare(dateTime, DateTime.Now);

            if (value > 0 && value <= 2)
                return true;
        }

        return false;
    }

    private static JwtSecurityToken ConvertJwtStringToJwtSecurityToken(string? jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var accessToken = handler.ReadJwtToken(jwt);

        return accessToken;
    }
}

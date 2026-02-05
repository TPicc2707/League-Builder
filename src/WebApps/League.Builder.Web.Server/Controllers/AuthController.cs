using League.Builder.Web.Server.Common;
using League.Builder.Web.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace League.Builder.Web.Server.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("auth")]
public class AuthController : ControllerBase
{
    private readonly KeycloakTokenService _tokenService;
    private readonly IConfiguration _configuration;

    public AuthController(KeycloakTokenService tokenService, IConfiguration configuration)
    {
        _tokenService = tokenService;
        _configuration = configuration;
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (result?.Principal?.Identity?.IsAuthenticated is not true)
            return StatusCode(204, new RefreshResult { Anonymous = true });

        var props = result.Properties;

        var refreshToken = props.GetTokenValue("refresh_token");
        var expiresAt = props.GetTokenValue("expires_at");

        if (string.IsNullOrEmpty(refreshToken))
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Unauthorized(new RefreshResult { Active = false });
        }

        if (!AuthorizationStatus.TokenIsExpiringSoon(expiresAt))
            return Ok(new RefreshResult { Refreshed = false });

        var newTokens = await _tokenService.RefreshTokensAsync(refreshToken);
        if (newTokens is null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Unauthorized(new RefreshResult { Active = false });
        }

        props.UpdateTokenValue("access_token", newTokens.AccessToken);
        props.UpdateTokenValue("refresh_token", newTokens.RefreshToken);
        props.UpdateTokenValue("expires_At", newTokens.ExpiresAt);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, props);

        return Ok(new RefreshResult { Refreshed = true });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var idToken = result.Properties.GetTokenValue("id_token");
        var authority = _configuration["KeycloakAuthority"];
        var signedOutRedirectUrl = _configuration["KeycloakSignedOutRedirectUrl"];

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        var keycloakLogout = $"{authority}/protocol/openid-connect/logout" +
                             $"?post_logout_redirect_uri={Uri.EscapeDataString(signedOutRedirectUrl)}" +
                             $"&id_token_hint={idToken}";
        return Ok(new { url = keycloakLogout });
    }

}

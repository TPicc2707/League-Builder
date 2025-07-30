using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using System.Security.Claims;

namespace League.Builder.Web.Server;

internal static class LoginLogoutEndpointRouteBuilderExtensions
{
    internal static IEndpointConventionBuilder MapLoginAndLogout(
        this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("authentication");

        group.MapGet(pattern: "/login", OnLogin).AllowAnonymous();
        group.MapPost(pattern: "/signout", OnLogout);
        group.MapGet(pattern: "/logout", async (HttpContext context, string? returnUrl) =>
        {
            var token = await context.GetTokenAsync("id_token");
            if (token is null) return Results.Redirect(returnUrl ?? "/");
            return TypedResults.SignOut(properties: new AuthenticationProperties
                {
                    RedirectUri = "/",
                    Items = { { "id_token_hint", token } }
                },
                [
                    CookieAuthenticationDefaults.AuthenticationScheme,
                        OpenIdConnectDefaults.AuthenticationScheme
                ]);
        });

        group.MapPost("/refresh", (RefreshRequest refreshRequest) =>
        {
            var refreshPrincipal = new ClaimsPrincipal(new ClaimsIdentity(IdentityConstants.BearerScheme));
            return TypedResults.SignIn(refreshPrincipal, properties: new AuthenticationProperties
                {
                    Items = { { "refresh_token", refreshRequest.RefreshToken } }
                }, IdentityConstants.BearerScheme);
        });

        return group;
    }

    static ChallengeHttpResult OnLogin() =>
        TypedResults.Challenge(properties: new AuthenticationProperties
        {
            RedirectUri = "/"
        });

    static SignOutHttpResult OnLogout() =>
        TypedResults.SignOut(properties: new AuthenticationProperties
        {
            RedirectUri = "/"
        },
        [
            CookieAuthenticationDefaults.AuthenticationScheme,
            OpenIdConnectDefaults.AuthenticationScheme
        ]);
}

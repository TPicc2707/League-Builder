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

        return group;
    }

    static ChallengeHttpResult OnLogin() =>
        TypedResults.Challenge(properties: new AuthenticationProperties
        {
            RedirectUri = "/",
           
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

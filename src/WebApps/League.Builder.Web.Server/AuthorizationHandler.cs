using Microsoft.AspNetCore.DataProtection;
using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace League.Builder.Web.Server;

public class AuthorizationHandler(IHttpContextAccessor httpContextAccessor, IDataProtectionProvider dataProtectionProvider, IJSRuntime jsRuntime)
    : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var httpContext = httpContextAccessor.HttpContext ??
            throw new InvalidOperationException("""
                No HttpContext available from the IHttpContextAccessor.
                """);

        if(httpContext is not null)
        {
            var result = await httpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var accessToken = result?.Properties?.GetTokenValue("access_token");

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

        }

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            httpContext.Items["ForceLogout"] = true;

        return response;
    }
}

using System.Net.Http.Headers;

namespace AI.API.Services;

public class KeycloakAuthHandler : DelegatingHandler
{
    private readonly KeycloakTokenService _tokenService;

    public KeycloakAuthHandler(KeycloakTokenService tokenService)
    {
        _tokenService = tokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await _tokenService.GetTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }
}

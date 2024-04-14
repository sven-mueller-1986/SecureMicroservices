using System.Net.Http.Headers;

namespace SecureMicroservices.Client.Authentication;

public class AuthenticationHandler(ITokenService tokenService)
    : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await tokenService.GetTokenAsync();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }
}

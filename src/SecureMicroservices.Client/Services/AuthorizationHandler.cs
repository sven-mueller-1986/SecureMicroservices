using System.Net.Http.Headers;

namespace SecureMicroservices.Client.Services;

public class AuthorizationHandler()
    : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        //var token = await tokenService.GetTokenAsync();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",  string.Empty);

        return await base.SendAsync(request, cancellationToken);
    }
}

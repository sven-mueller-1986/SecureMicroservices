using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace SecureMicroservices.Client.Authentication;

public class TokenHybridService(IHttpContextAccessor accessor)
    : ITokenService
{
    public async Task<string> GetTokenAsync()
    {
        if(accessor.HttpContext is null)
            throw new ArgumentNullException(nameof(accessor));

        var token = await accessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

        return token;
    }
}

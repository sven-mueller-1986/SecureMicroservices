
using SecureMicroservices.Client.Models;

namespace SecureMicroservices.Client.Services;

public class TokenService(IIdentityApi identityApi)
    : ITokenService
{
    private BearerToken? _token;

    public async Task<string> GetTokenAsync()
    {
        if(_token is not null && _token.ExpirationDate < DateTime.UtcNow)
            return _token.Token;
        
        var token = await identityApi.GetTokenAsync(new ClientCredential());
        _token = new BearerToken 
        { 
            Token = token.AccessToken,
            ExpirationDate = DateTime.UtcNow.AddSeconds(token.ExpiresIn)
        };

        return _token.Token;
    }
}

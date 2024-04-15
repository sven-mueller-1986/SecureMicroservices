using Refit;
using SecureMicroservices.Client.Models;

namespace SecureMicroservices.Client.Authentication;

public interface IIdentityApi
{
    [Post("/connect/token")]
    Task<IdentityToken> GetTokenAsync([Body(BodySerializationMethod.UrlEncoded)] ClientCredential credential);

    [Get("/connect/userinfo")]
    Task<string> GetUserInfoAsync();
}

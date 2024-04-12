using Refit;
using SecureMicroservices.Client.Models;

namespace SecureMicroservices.Client.Services;

public interface IIdentityApi
{
    [Post("/connect/token")]
    Task<IdentityToken> GetTokenAsync([Body(BodySerializationMethod.UrlEncoded)] ClientCredential credential);
}

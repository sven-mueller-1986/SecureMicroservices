using Refit;

namespace SecureMicroservices.Client.Authentication;

public interface IIdentityApi
{
    [Post("/connect/token")]
    Task<IdentityToken> GetTokenAsync([Body(BodySerializationMethod.UrlEncoded)] ClientCredential credential);
}

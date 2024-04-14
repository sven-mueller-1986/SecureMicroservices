using System.Text.Json.Serialization;

namespace SecureMicroservices.Client.Authentication;

public class ClientCredential
{
    public ClientCredential(string grantType, string scope, string clientId, string clientSecret)
    {
        GrantType = grantType;
        Scope = scope;
        ClientId = clientId;
        ClientSecret = clientSecret;
    }

    [JsonPropertyName("grant_type")]
    public string GrantType { get; }

    [JsonPropertyName("scope")]
    public string Scope { get; }

    [JsonPropertyName("client_id")]
    public string ClientId { get; }

    [JsonPropertyName("client_secret")]
    public string ClientSecret { get; }
}

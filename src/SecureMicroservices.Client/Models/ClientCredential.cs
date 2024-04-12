using System.Text.Json.Serialization;

namespace SecureMicroservices.Client.Models;

public class ClientCredential
{
    [JsonPropertyName("grant_type")]
    public string GrantType { get; } = "client_credentials";

    [JsonPropertyName("scope")]
    public string Scope { get; } = "movieAPI";

    [JsonPropertyName("client_id")]
    public string ClientId { get; } = "movieClient";

    [JsonPropertyName("client_secret")]
    public string ClientSecret { get; } = "secret";
}

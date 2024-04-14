namespace SecureMicroservices.Client.Authentication;

public interface ITokenService
{
    Task<string> GetTokenAsync();
}
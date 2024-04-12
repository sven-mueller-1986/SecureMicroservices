namespace SecureMicroservices.Client.Services;

public interface ITokenService
{
    Task<string> GetTokenAsync();
}
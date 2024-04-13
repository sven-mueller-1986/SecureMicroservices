using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace SecureMicroservices.Identity;

public static class Configuration
{
    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "movieClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "movieAPI" }
            },
            new Client
            {
                ClientId = "movies_mvc_client",
                ClientName = "Movies MVC Web App",
                AllowedGrantTypes = GrantTypes.Code,
                AllowRememberConsent = false,
                RedirectUris = new List<string>
                {
                    "https://localhost:5052/signin-oidc"
                },
                PostLogoutRedirectUris = new List<string>
                {
                    "https://localhost:5052/signout-callback-oidc"
                },
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("movieAPI", "Movie API")
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {

        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static List<TestUser> TestUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1b648be9-58fa-43d6-93be-af2b407448cb",
                Username = "Torben",
                Password = "Test",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.GivenName, "Torben"),
                    new Claim(JwtClaimTypes.FamilyName, "Test")
                }
            }
        };
}

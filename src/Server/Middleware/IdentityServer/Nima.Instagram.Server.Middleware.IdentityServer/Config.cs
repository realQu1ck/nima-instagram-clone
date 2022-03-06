using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace Nima.Instagram.Server.Middleware.IdentityServer
{
    public class Config
    {
        private readonly static string FrontHostURL = "https://localhost:7178";
        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client()
            {
                ClientId = "oauthClientInternetStoreID",
                ClientName = "OAuthClientSecurity",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {new Secret("+/-instagram@!!**/9845SecretWoauth".Sha256())},
                AllowedScopes = new List<string> { "newInternetStore.Read" }
            },
            new Client()
            {
                ClientId = "oidcClientInternetStoreID",
                ClientName = "Internet Store Client -> Security",
                AllowedGrantTypes = GrantTypes.Hybrid,
                RequireClientSecret = true,
                AllowRememberConsent = false,
                RequireConsent = false,
                AllowedCorsOrigins = new[] {"https://localhost:7178"},
                RedirectUris = new List<string>
                {
                    "https://localhost:7178/signin-oidc",
                    "https://localhost:7078/signin-oidc"
                },
                PostLogoutRedirectUris = new List<string>
                {
                    "https://localhost:7178/signout-callback-oidc",
                    "https://localhost:7078/signout-callback-oidc"
                },
                ClientSecrets = new List<Secret> {new Secret("+844/-58ClientInstagram$%2{ss-sda-56687}oauth".Sha256())}, // change me!
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "roles",
                    "newInternetStore.Read",
                },
                AllowAccessTokensViaBrowser =true,
                AllowOfflineAccess = true,
                RequirePkce = false,
                AlwaysIncludeUserClaimsInIdToken = true,
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("newInternetStore.Read", "Read Internet Store API"),
            new ApiScope("newInternetStore.Write", "Write Internet Store API")
        };


        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
             new ApiResource
                {
                    Name = "newInternetStore",
                    DisplayName = "Internet Store API Secuirty #1",
                    Description = "Internet Store Api Security",
                    Scopes = new List<string> {
                        "newInternetStore.Write",
                        "newInternetStore.Read"},
                    ApiSecrets = new List<Secret> {new Secret("@//#InternetStoreScopes//#@@!".Sha256())},
                    UserClaims = new List<string> { "roles" }
                }
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource
            {
                Name = "roles",
                UserClaims = new List<string> { "role" }
            }
        };


        public static List<TestUser> TestUsers => new List<TestUser>
        {
            new TestUser()
            {
                SubjectId = "SBE86359-073C-434B-AD2D-A3932222DABE",
                Username = "nimahosseini",
                Password = "nimahosseini",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Email, "nima13727@gmail.com"),
                    new Claim(JwtClaimTypes.GivenName, "realQu1ck"),
                    new Claim(JwtClaimTypes.FamilyName, "hosseini")
                }
            }
        };
    }
}

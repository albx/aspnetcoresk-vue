using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSk.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new ApiResource[]
            {
                new ApiResource("MyFeaturesApi", "My Features API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {
                new Client
                {
                    ClientId = "aspnetcoresk.vue",
                    ClientName = "AspnetCoreSK Webapp",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    AllowedCorsOrigins = { "https://localhost:44388" },
                    RedirectUris = { "https://localhost:44388/callback" },
                    PostLogoutRedirectUris = { "https://localhost:44388/" },
                    ClientSecrets =
                    {
                        new Secret("secret1".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "MyFeaturesApi"
                    }
                }
            };
        }
    }
}

using JokeOfTheDay.Models;
using JokeOfTheDay.Services;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace JokeOfTheDay.Middleware
{
    public class TokenValidation
    { 
        public static TokenValidationParameters GetCognitoTokenValidationParams()
        {
            AppSecretModel secrets = new SecretManagerService().getAppSecrets("AppSecret");

            var cognitoIssuer = $"https://cognito-idp.eu-west-1.amazonaws.com/{secrets.user_pool_id}";

            var jwtKeySetUrl = $"{cognitoIssuer}/.well-known/jwks.json";

            var cognitoAudience = secrets.client_id;
            return new TokenValidationParameters {
                IssuerSigningKeyResolver = (s, securityToken, identifier, parameters) => {
                    //var keys = new HttpClient().GetFromJsonAsync<JsonWebKeySet>(jwtKeySetUrl);
                    //return (IEnumerable<SecurityKey>)keys;

                    // get JsonWebKeySet from AWS
                    var json = new WebClient().DownloadString(jwtKeySetUrl);
                    // serialize the result
                    var keys =  JsonConvert.DeserializeObject<JsonWebKeySet>(json).Keys;
                    // cast the result to be the type expected by IssuerSigningKeyResolver
                    return (IEnumerable<SecurityKey>)keys;
                },
                    ValidIssuer = cognitoIssuer,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    //ValidAudience = cognitoAudience, //not checking ID Token
                    ValidateAudience = false,
                    RoleClaimType = "cognito:groups",
            };
        }
    }
}

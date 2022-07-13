using JokeOfTheDay.Services;
using RestSharp;
using System.Text.Json.Nodes;

namespace JokeOfTheDay.Middleware
{
    public class TokenCache
    {
        private static Dictionary<string, Token> tokens = new();

        public class Token
        {
            private DateTime expires;
            public string id_token;
            public string token_type;
            public string access_token;
            public string refresh_token;

            public Token(string id_token, string access_token, string refresh_token, string token_type)
            {
                if (!token_type.Equals("Bearer"))
                    throw new InvalidDataException("Token not valid.");

                this.id_token = id_token;
                this.token_type = token_type;
                this.access_token = access_token;
                this.refresh_token = refresh_token;
                this.expires = DateTime.Now.AddMinutes(5);
            }

            public bool hasNotExpired()
            {
                return DateTime.Now < expires;
            }
        }

        public static string? AddNewToken(string token)
        {
            var client = new RestClient();
            Models.AppSecretModel secrets = new SecretManagerService().getAppSecrets("AppSecret");
            var request = new RestRequest("https://jokesapi.auth.eu-west-1.amazoncognito.com/oauth2/token/", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("code", token);
            request.AddParameter("client_id", secrets.client_id);
            request.AddParameter("redirect_uri", "http://localhost:4200/session");
            request.AddParameter("scope", "openid");
            request.AddParameter("client_secret", secrets.client_secret);
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                JsonNode result = JsonNode.Parse(response.Content);

                string id_token = result["id_token"].ToString();
                string token_type = result["token_type"].ToString();
                string access_token = result["access_token"].ToString();
                string refresh_token = result["refresh_token"].ToString();
                Guid newKey = Guid.NewGuid();

                tokens.Add(newKey.ToString(), new Token(id_token, access_token, refresh_token, token_type));

                return newKey.ToString();
            }
            return null;
        }

        public static string ValidateToken(string key)
        {
            if (tokens.ContainsKey(key))
            {
                Token token = tokens["key"];

                return token.hasNotExpired() ? token.access_token : String.Empty;
            }

            return String.Empty;
        }
    }
}

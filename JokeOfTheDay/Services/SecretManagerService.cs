using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Extensions.Caching;
using Newtonsoft.Json.Linq;
using JokeOfTheDay.Models;


namespace JokeOfTheDay.Services
{
    public class SecretManagerService : ISingletonSecretManagerService
    {
        private readonly IAmazonSecretsManager secretsManager;
        private readonly SecretsManagerCache cache;
        public SecretManagerService()
        {

            this.secretsManager = new AmazonSecretsManagerClient(RegionEndpoint.USEast1);
            this.cache = new SecretsManagerCache(this.secretsManager);

        }

        public DbSecretModel getDatabaseCredential(string secretID)
        {
            try
            {
                var response = this.cache.GetSecretString(secretID).Result;
                JObject jObject = JObject.Parse(response);
                return new DbSecretModel
                {
                    Url = jObject["url"].ToObject<string>(),
                    Port = jObject["port"].ToObject<string>(),
                    Password = jObject["password"].ToObject<string>(),
                    Username = jObject["username"].ToObject<string>()
                };
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

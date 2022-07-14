using JokeOfTheDay.Models;

namespace JokeOfTheDay.Services
{
    public interface ISingletonSecretManagerService
    {
        DbSecretModel getDatabaseCredential(string secretID);

        AppSecretModel getAppSecrets(string secretID);
    }
}

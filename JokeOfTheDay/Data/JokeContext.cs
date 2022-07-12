using JokeOfTheDay.Models;
using JokeOfTheDay.Services;
using Microsoft.EntityFrameworkCore;

namespace JokeOfTheDay.Data
{
    public class JokeContext : DbContext
    {
        private ISingletonSecretManagerService secretManagerService;
        private IConfiguration configuration;

        public DbSet<Joke> Jokes { get; set; }
        public DbSet<Models.Joke_of_the_day> JokesOfTheDay { get; set; }

        public JokeContext(ISingletonSecretManagerService secretManagerService, IConfiguration configuration)
        {
            this.secretManagerService = secretManagerService;
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            else
            {
                string connectionString = getConnectionString();
                optionsBuilder.UseSqlServer(connectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }

        private string getConnectionString()
        {
            if (configuration.GetSection("ConnectionString").Exists())
            {
                return configuration.GetSection("ConnectionString").Value.ToString();
            }

            else if (configuration.GetSection("DatabaseSecretID").Exists())
            {
                var secretID = configuration.GetSection("DatabaseSecretID").Value.ToString();
                DbSecretModel secretModel = this.secretManagerService.getDatabaseCredential(secretID);
                return $"Server='{secretModel.Url}';" +
                    $" Port='{secretModel.Port}';" +
                    $" User Id='{secretModel.Username}'; " +
                    $"Password='{secretModel.Password}';";
            }
            else
            {
                // error
                throw new Exception();
            }
        }
    }
}

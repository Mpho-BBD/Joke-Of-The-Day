using JokeOfTheDay.Models;
using JokeOfTheDay.Services;
using Microsoft.EntityFrameworkCore;
namespace JokeOfTheDay.Data
{
    public class JokeContext : DbContext
    {
        private ISingletonSecretManagerService secretManagerService;
        private IConfiguration configuration;

        public DbSet<Joke> Joke { get; set; }
        public DbSet<JokeOfTheDayM> JokeOfTheDay { get; set; }

        public JokeContext(ISingletonSecretManagerService secretManagerService, IConfiguration configuration)
        {
            this.secretManagerService = secretManagerService;
            this.configuration = configuration;
        }

        //TODO: OnModelCreating for cool relationship binding 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            else
            {
                string connectionString = getConnectionString();
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
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
                Models.DbSecretModel secretModel = this.secretManagerService.getDatabaseCredential(secretID);
                return $"Server='{secretModel.Url}'; " +
                        $"Port={secretModel.Port}; " +
                        $"Database=jokesdb; " +
                        $"Uid='{secretModel.Username}'; " +
                        $"Pwd='{secretModel.Password}'; " +
                        $"SslMode=Preferred; ";
            }
            else
            {
                // error
                throw new Exception();
            }
        }
    }
}

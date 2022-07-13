using System.ComponentModel.DataAnnotations.Schema;

namespace JokeOfTheDay.Models
{
    [NotMapped]
    public class AppSecretModel
    {
        public string? client_id { get; set; }
        public string? redirect_url { get; set; }
        public string? client_secret { get; set; }

        public string? user_pool_id { get; set; }
    }
}

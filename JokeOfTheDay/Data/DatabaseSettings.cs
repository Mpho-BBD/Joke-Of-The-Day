namespace JokeOfTheDay.Data
{
    public class DatabaseSettings
    {
        public const string SectionName = "Database";
        public string ConnectionPort { get; set; } = default!;
        public string ConnectionUsername { get; set; } = default!;
        public string ConnectionUrl { get; set; } = default!;
        public string ConnectionPassword { get; set; } = default!;

    }
}

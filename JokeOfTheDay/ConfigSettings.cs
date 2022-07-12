using Newtonsoft.Json.Linq;

namespace JokeOfTheDay
{
    public class ConfigSettings : IConfigSettings
    {
        private string _port;
        private string _username;
        private string _url;
        private string _password;

        public ConfigSettings()
        {
            Init();
        }
        public void Init()
        {
            var secretValues = JObject.Parse(SecretsManager.GetSecret());
            if (secretValues != null)
            {
                _port = secretValues["port"].ToString();
                _username = secretValues["username"].ToString();
                _url = secretValues["url"].ToString();
                _password = secretValues["password"].ToString();

            }
        }
        public string Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
    }
    public interface IConfigSettings
    {
        string Port
        {
            get;
            set;
        }
        string Username
        {
            get;
            set;
        }
        string Url
        {
            get;
            set;
        }
        string Password
        {
            get;
            set;
        }
    }
}

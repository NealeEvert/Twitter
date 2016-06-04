namespace Twitter.Core.Implementation
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string GetAppSetting(string key)
        {
            switch (key)
            {
                case "UserDataFile":
                    return "D:\\Projects\\Twitter\\data\\user.txt";
                case "TweetDataFile":
                    return "D:\\Projects\\Twitter\\data\\tweet.txt";
            }
            return string.Empty;
        }
    }
}

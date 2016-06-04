using System.Configuration;

namespace Twitter.Core.Implementation
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string GetAppSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}

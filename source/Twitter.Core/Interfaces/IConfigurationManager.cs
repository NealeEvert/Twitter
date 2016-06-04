namespace Twitter.Core
{
    public interface IConfigurationManager
    {
        /// <summary>
        /// Used to get a value from the configuration file of the project
        /// </summary>
        /// <param name="key">The key of the value that is to be returned</param>
        /// <returns>The value of the key being requested</returns>
        string GetAppSetting(string key);
    }
}

using System.IO;
using System.Text;
using Twitter.Core;
using Twitter.Core.Config;
using Twitter.Data.FlatFile.Interfaces;

namespace Twitter.Data.FlatFile.Implementation
{
    /// <summary>
    /// Flat file data reader
    /// </summary>
    public class FileDataReader : IFileDataReader
    {
        private readonly IConfigurationManager _configurationManager;

        public FileDataReader()
        {
            _configurationManager = Factory.Resolve<IConfigurationManager>();
        }

        public FileDataReader(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        /// <summary>
        /// Reads data from a flat file
        /// </summary>
        /// <param name="configurationKey">Configuration key that holds the path to the file</param>
        /// <returns>Array of lines read from the file</returns>
        public string[] GetFileData(string configurationKey)
        {
            return File.ReadAllLines(GetFilePath(configurationKey), Encoding.ASCII);
        }

        private string GetFilePath(string key)
        {
            return _configurationManager.GetAppSetting(key);
        }
    }
}
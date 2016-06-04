using System.IO;
using Twitter.Core;
using Twitter.Core.Config;
using Twitter.Data.FlatFile.Interfaces;

namespace Twitter.Data.FlatFile.Implementation
{
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

        public string[] GetFileData(string configurationKey)
        {
            //TODO: Needs to take into account ASCII 7-Bit file encoding
            return File.ReadAllLines(GetFilePath(configurationKey));
        }

        private string GetFilePath(string key)
        {
            return _configurationManager.GetAppSetting(key);
        }
    }
}
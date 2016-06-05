namespace Twitter.Data.FlatFile.Interfaces
{
    /// <summary>
    /// Flat file data reader
    /// </summary>
    public interface IFileDataReader
    {
        /// <summary>
        /// Reads data from a flat file
        /// </summary>
        /// <param name="configurationKey">Configuration key that holds the path to the file</param>
        /// <returns>Array of lines read from the file</returns>
        string[] GetFileData(string configurationKey);
    }
}

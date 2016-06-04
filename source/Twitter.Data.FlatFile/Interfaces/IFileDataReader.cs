namespace Twitter.Data.FlatFile.Interfaces
{
    public interface IFileDataReader
    {
        string[] GetFileData(string configurationKey);
    }
}

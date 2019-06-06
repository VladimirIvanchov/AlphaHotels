namespace AlphaHotel.Infrastructure.ReaderProvider
{
    public interface IFileReader
    {
        string[] ReadAll(string path);
    }
}

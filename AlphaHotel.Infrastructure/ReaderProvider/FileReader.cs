using System.IO;

namespace AlphaHotel.Infrastructure.ReaderProvider
{
    public class FileReader : IFileReader
    {
        public string[] ReadAll(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}

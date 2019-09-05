using System.IO;

namespace MadreDeDiosAdventureFileManager
{
    public class FileReader : IFileReader
    {
        private readonly string _inputFileName;

        public FileReader(string inputFileName)
        {
            _inputFileName = inputFileName;
        }

        public string Read()
        {
            return File.ReadAllText(_inputFileName);
        }
    }
}

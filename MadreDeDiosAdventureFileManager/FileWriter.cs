using System.IO;

namespace MadreDeDiosAdventureFileManager
{
    public class FileWriter
    {
        private readonly string _outputFileName;

        public FileWriter(string outputFileName)
        {
            _outputFileName = outputFileName;
        }

        public void Write()
        {
            if (!File.Exists(_outputFileName))
            {
                File.Create(_outputFileName);
            }
        }
    }
}

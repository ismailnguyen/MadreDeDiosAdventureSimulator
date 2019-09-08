using MadreDeDiosAdventure;
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

        public void Write(Map map)
        {
            if (map == null)
                return;

            string outputContent = map.ToString();

            File.WriteAllText(_outputFileName, outputContent);
        }
    }
}

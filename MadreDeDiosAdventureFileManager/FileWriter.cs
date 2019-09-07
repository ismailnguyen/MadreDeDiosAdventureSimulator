using MadreDeDiosAdventure;
using System.IO;
using System.Text;

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

            if (!File.Exists(_outputFileName))
            {
                File.Create(_outputFileName);
            }

            string outputContent = map.ToString();

            File.WriteAllText(_outputFileName, outputContent);
        }
    }
}

using MadreDeDiosAdventure;

namespace MadreDeDiosAdventureFileManager
{
    public class FileConverter
    {
        private readonly IFileReader _fileReader;

        public FileConverter(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public Map Convert()
        {
            _fileReader.Read();

            return new Map(0, 0, null, null, null);
        }
    }
}

using MadreDeDiosAdventure;

namespace MadreDeDiosAdventureFileManager
{
    public class FileConverter
    {
        private readonly IFileReader _fileReader;
        private readonly IContentParser _contentParser;

        public FileConverter(IFileReader fileReader, IContentParser contentParser)
        {
            _fileReader = fileReader;
            _contentParser = contentParser;
        }

        public Map Convert()
        {
            string fileContent = _fileReader.Read();

            return _contentParser.Parse(fileContent);
        }
    }
}

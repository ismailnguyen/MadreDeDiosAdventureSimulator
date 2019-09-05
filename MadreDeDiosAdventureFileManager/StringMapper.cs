using MadreDeDiosAdventure;

namespace MadreDeDiosAdventureFileManager
{
    public class StringMapper
    {
        private readonly string _content;

        public StringMapper(string content)
        {
            _content = content;
        }

        public Map Map()
        {
            string[] elements = _content.Split(" - ");

            int width = 0;
            int.TryParse(elements[1], out width);

            return new Map
            {
                Width = width
            };
        }
    }
}

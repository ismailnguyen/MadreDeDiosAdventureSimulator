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

            int.TryParse(elements[1], out int width);

            int.TryParse(elements[2], out int height);

            return new Map
            {
                Width = width,
                Height = height
            };
        }
    }
}

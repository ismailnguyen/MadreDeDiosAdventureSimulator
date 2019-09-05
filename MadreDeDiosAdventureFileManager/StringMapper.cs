using MadreDeDiosAdventure;
using System.Collections.Generic;

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

            int width = 0, height = 0;
            if (elements[0] == "C")
            {
                int.TryParse(elements[1], out width);
                int.TryParse(elements[2], out height);
            }

            var mountains = new List<Mountain>();
            if (elements[0] == "M")
            {
                int.TryParse(elements[1], out int horizontalAxis);
                int.TryParse(elements[2], out int verticalAxis);

                mountains.Add(new Mountain(horizontalAxis, verticalAxis));
            }

            var treasures = new List<Treasure>();
            if (elements[0] == "T")
            {
                int.TryParse(elements[1], out int horizontalAxis);
                int.TryParse(elements[2], out int verticalAxis);
                int.TryParse(elements[3], out int count);

                treasures.Add(new Treasure(horizontalAxis, verticalAxis, count));
            }

            return new Map
            {
                Width = width,
                Height = height,
                Mountains = mountains,
                Treasures = treasures
            };
        }
    }
}

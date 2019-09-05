using System.Collections.Generic;

namespace MadreDeDiosAdventure
{
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public IEnumerable<Mountain> Mountains { get; set; }
        public IEnumerable<Treasure> Treasures { get; set; }
        public IEnumerable<Adventurer> Adventurers { get; set; }
    }
}

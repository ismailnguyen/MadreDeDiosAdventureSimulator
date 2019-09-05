using System;
using System.Collections.Generic;
using System.Linq;

namespace MadreDeDiosAdventure
{
    public class Map
    {
        public int Width { get; }
        public int Height { get; }

        public IEnumerable<Mountain> Mountains { get; }
        public IEnumerable<Treasure> Treasures { get; }
        public IEnumerable<Adventurer> Adventurers { get; }

        public Map(
            int width, 
            int height,
            IEnumerable<Mountain> mountains,
            IEnumerable<Treasure> treasures,
            IEnumerable<Adventurer> adventurers)
        {
            Width = width;
            Height = height;
            Mountains = mountains;
            Treasures = treasures;
            Adventurers = adventurers;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Map))
                return false;

            var map = obj as Map;

            if (Width != map.Width)
                return false;

            if (Height != map.Height)
                return false;

            if (!AreEquals(Mountains, map.Mountains))
                return false;

            if (!AreEquals(Treasures, map.Treasures))
                return false;

            if (!AreEquals(Adventurers, map.Adventurers))
                return false;

            return true;
        }

        private bool AreEquals<T>(IEnumerable<T> list1, IEnumerable<T> list2)
        {
            if (list1.Count() != list2.Count())
                return false;

            var firstNotSecond = list1.Except(list2).ToList();
            var secondNotFirst = list2.Except(list1).ToList();

            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Width, Height, Mountains, Treasures, Adventurers);
        }
    }
}

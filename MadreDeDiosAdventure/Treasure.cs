using System;

namespace MadreDeDiosAdventure
{
    public class Treasure
    {
        public Position Position { get; }
        public int Count { get; set; }

        public Treasure(Position position, int count)
        {
            Position = position;
            Count = count;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Treasure))
                return false;

            var treasure = obj as Treasure;

            return Position == treasure.Position
                && Count == treasure.Count;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Position, Count);
        }

        public override string ToString()
        {
            return $"T - { Position } - { Count }";
        }
    }
}
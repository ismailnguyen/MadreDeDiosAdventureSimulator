using System;

namespace MadreDeDiosAdventure
{
    public class Treasure
    {
        public int HorizontalAxis { get; }
        public int VerticalAxis { get; }
        public int Count { get; }

        public Treasure(int horizontalAxis, int verticalAxis, int count)
        {
            HorizontalAxis = horizontalAxis;
            VerticalAxis = verticalAxis;
            Count = count;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Treasure))
                return false;

            var treasure = obj as Treasure;

            return HorizontalAxis == treasure.HorizontalAxis
                && VerticalAxis == treasure.VerticalAxis
                && Count == treasure.Count;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(HorizontalAxis, VerticalAxis, Count);
        }

        public override string ToString()
        {
            return $"T - { HorizontalAxis } - { VerticalAxis } - { Count }";
        }
    }
}
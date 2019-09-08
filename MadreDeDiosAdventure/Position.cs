using System;

namespace MadreDeDiosAdventure
{
    public class Position
    {
        public int HorizontalAxis { get; set; }
        public int VerticalAxis { get; set; }

        public Position(int horizontalAxis, int verticalAxis)
        {
            HorizontalAxis = horizontalAxis;
            VerticalAxis = verticalAxis;
        }

        public Position Next(Orientation orientation)
        {
            if (orientation.Equals(Orientation.North))
            {
                return new Position(HorizontalAxis, VerticalAxis - 1);
            }

            if (orientation.Equals(Orientation.South))
            {
                return new Position(HorizontalAxis, VerticalAxis + 1);
            }

            if (orientation.Equals(Orientation.Est))
            {
                return new Position(HorizontalAxis + 1, VerticalAxis);
            }

            if (orientation.Equals(Orientation.West))
            {
                return new Position(HorizontalAxis - 1, VerticalAxis);
            }

            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Position))
                return false;

            var position = obj as Position;

            return HorizontalAxis == position.HorizontalAxis
                && VerticalAxis == position.VerticalAxis;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(HorizontalAxis, VerticalAxis);
        }

        public override string ToString()
        {
            return $"{ HorizontalAxis } - { VerticalAxis }";
        }
    }
}

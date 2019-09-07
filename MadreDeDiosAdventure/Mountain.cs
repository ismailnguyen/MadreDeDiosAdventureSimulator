using System;

namespace MadreDeDiosAdventure
{
    public class Mountain
    {
        public int HorizontalAxis { get; }
        public int VerticalAxis { get; }

        public Mountain(int horizontalAxis, int verticalAxis)
        {
            HorizontalAxis = horizontalAxis;
            VerticalAxis = verticalAxis;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Mountain))
                return false;

            var moutain = obj as Mountain;

            return HorizontalAxis == moutain.HorizontalAxis
                && VerticalAxis == moutain.VerticalAxis;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(HorizontalAxis, VerticalAxis);
        }

        public override string ToString()
        {
            return $"M - { HorizontalAxis } - { VerticalAxis }";
        }
    }
}
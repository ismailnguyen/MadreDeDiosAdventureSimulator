using System;

namespace MadreDeDiosAdventure
{
    public class Mountain
    {
        public Position Position { get; }

        public Mountain(Position position)
        {
            Position = position;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Mountain))
                return false;

            var moutain = obj as Mountain;

            return Position == moutain.Position;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Position);
        }

        public override string ToString()
        {
            return $"M - { Position }";
        }
    }
}
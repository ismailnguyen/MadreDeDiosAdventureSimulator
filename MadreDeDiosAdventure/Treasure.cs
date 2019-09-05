using System;

namespace MadreDeDiosAdventure
{
    public class Treasure
    {
        private readonly int _horizontalAxis;
        private readonly int _verticalAxis;
        private readonly int _count;

        public Treasure(int horizontalAxis, int verticalAxis, int count)
        {
            _horizontalAxis = horizontalAxis;
            _verticalAxis = verticalAxis;
            _count = count;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Treasure))
                return false;

            var treasure = obj as Treasure;

            return _horizontalAxis == treasure._horizontalAxis
                && _verticalAxis == treasure._verticalAxis
                && _count == treasure._count;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_horizontalAxis, _verticalAxis, _count);
        }
    }
}
using System;

namespace MadreDeDiosAdventure
{
    public class Mountain
    {
        private readonly int _horizontalAxis;
        private readonly int _verticalAxis;

        public Mountain(int horizontalAxis, int verticalAxis)
        {
            _horizontalAxis = horizontalAxis;
            _verticalAxis = verticalAxis;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Mountain))
                return false;

            var moutain = obj as Mountain;

            return _horizontalAxis == moutain._horizontalAxis
                && _verticalAxis == moutain._verticalAxis;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_horizontalAxis, _verticalAxis);
        }
    }
}
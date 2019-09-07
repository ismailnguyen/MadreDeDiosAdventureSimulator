using System;

namespace MadreDeDiosAdventure
{
    public class Orientation
    {
        public static Orientation North = new Orientation("N", West, Est);
        public static Orientation South = new Orientation("S", Est, West);
        public static Orientation Est = new Orientation("E", North, South);
        public static Orientation West = new Orientation("O", South, North);

        private readonly string _code;
        public Orientation Left { get;  }
        public Orientation Right { get; }

        private Orientation(string code, Orientation left, Orientation right)
        {
            _code = code;
            Left = left;
            Right = right;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Orientation))
                return false;

            var orientation = obj as Orientation;

            return _code.Equals(orientation._code);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_code);
        }

        public override string ToString()
        {
            return _code;
        }
    }
}

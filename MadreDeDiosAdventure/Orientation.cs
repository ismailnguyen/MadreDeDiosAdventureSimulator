using System;

namespace MadreDeDiosAdventure
{
    public class Orientation
    {
        public static Orientation North = new Orientation("North", West, Est);
        public static Orientation South = new Orientation("South", Est, West);
        public static Orientation Est = new Orientation("Est", North, South);
        public static Orientation West = new Orientation("West", South, North);

        private readonly string _name;
        public Orientation Left { get;  }
        public Orientation Right { get; }

        private Orientation(string name, Orientation left, Orientation right)
        {
            _name = name;
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

            return _name.Equals(orientation._name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_name);
        }
    }
}

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

        private Orientation(string code, Orientation left, Orientation right)
        {
            _code = code;
        }

        public Orientation Right()
        {
            switch (_code)
            {
                case "N":
                    return Est;

                case "E":
                    return South;

                case "S":
                    return West;

                case "O":
                default:
                    return North;
            }
        }

        public Orientation Left()
        {
            switch (_code)
            {
                case "N":
                    return West;

                case "E":
                    return North;

                case "S":
                    return Est;

                case "O":
                default:
                    return South;

            }
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

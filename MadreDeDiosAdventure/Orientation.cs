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
    }
}

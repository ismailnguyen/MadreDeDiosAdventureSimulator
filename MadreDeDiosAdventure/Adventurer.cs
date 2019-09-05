using System;
using System.Collections.Generic;

namespace MadreDeDiosAdventure
{
    public class Adventurer
    {
        public string Name { get; }
        public int HorizontalAxis { get; set; }
        public int VerticalAxis { get; set; }
        public Orientation Orientation { get; set; }
        public IEnumerable<Motion> MotionSequence { get; }
        public int FoundTreasuresCount { get; set; }

        public Adventurer(
            string name, 
            int horizontalAxis, 
            int verticalAxis, 
            Orientation orientation, 
            IEnumerable<Motion> motionSequence
        )
        {
            Name = name;
            HorizontalAxis = horizontalAxis;
            VerticalAxis = verticalAxis;
            Orientation = orientation;
            MotionSequence = motionSequence;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Adventurer))
                return false;

            var adventurer = obj as Adventurer;

            return Name.Equals(adventurer.Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}